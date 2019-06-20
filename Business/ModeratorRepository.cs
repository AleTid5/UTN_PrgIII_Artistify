using Common;
using Common.Senders;
using Common.Transformers;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ModeratorRepository : UserRepository
    {
        public ModeratorRepository()
        {
            this.Table = "Users_Moderators";
        }

        public new void AuthenticateOrFail(String Email, String Password)
        {
            try {
                this.CheckCredentialsOrFail(Email, Password);
                this.CheckOrFail();
                this.SqlConnection.Close();
                this.UpdateUserLogin(Session.user.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void Add(Moderator moderator)
        {
            try {
                int lastID = this.Add((AbstractUser)moderator);
                String QueryTemplate = "INSERT INTO Users_Moderators (Id, Administrator) VALUES ({0}, {1})";
                String Query = String.Format(QueryTemplate, lastID, Session.user.Id);
                this.ExecInsert(Query);
                EmailSender.UserAdd((AbstractUser)moderator, "Moderador");
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public List<Moderator> FindAll()
        {
            try {
                String Query = String.Format("SELECT * FROM {0} A INNER JOIN Users U ON A.Id = U.Id", this.Table);
                this.ExecSelect(Query);

                List<Moderator> moderators = new List<Moderator>();

                while (this.SqlDataReader.Read())
                    moderators.Add(new Moderator(this.GetRowCasted()));

                return moderators;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        private void CheckOrFail()
        {
            String QueryTemplate = "SELECT TOP 1 Users.*" +
                                   "FROM Users_Moderators A" +
                                   "INNER JOIN Users ON Users.Id = A.Id" +
                                   "WHERE A.Id = {0}";
            String Query = String.Format(QueryTemplate, Session.user.Id);
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            this.AssertOrFail("El usuario ingresado no es moderador");
        }
    }
}
