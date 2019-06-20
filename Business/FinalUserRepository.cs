using Common;
using Common.Exceptions;
using Common.Senders;
using Common.Transformers;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FinalUserRepository : UserRepository
    {
        public FinalUserRepository()
        {
            this.Table = "Users_Finals";
        }

        public new void AuthenticateOrFail(String email, String password)
        {
            try {
                this.CheckCredentialsOrFail(email, password);
                this.CheckOrFail();
                this.SqlConnection.Close();
                this.UpdateUserLogin(Session.user.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void Add(FinalUser finalUser)
        {
            try {
                int lastID = this.Add((AbstractUser)finalUser);
                String QueryTemplate = "INSERT INTO {0} (Id, ImageSource, Telephone, ParentUser) " +
                                       "VALUES ({1}, '{2}', '{3}', {4})";
                String Query = String.Format(QueryTemplate, this.Table,
                                                            lastID,
                                                            finalUser.ImageSource,
                                                            finalUser.Telephone,
                                                            this.GetUserIdOrNull(finalUser.ParentUser));
                this.ExecInsert(Query);
                EmailSender.UserAdd((AbstractUser)finalUser);
            } catch (SqlException ex) {
                throw new SqlParsedException(ex.Number, ex.Message);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public FinalUser FindById(int Id)
        {
            try {
                if (0 == Id) return null;

                String Query = String.Format("SELECT TOP 1 * FROM {0} A INNER JOIN Users U ON A.Id = U.Id WHERE U.Status = 'A' AND A.Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted(this.GetRowCasted());
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        private FinalUser GetRowCasted(AbstractUser abstractUser)
        {
            return new FinalUser(abstractUser) {
                ImageSource = DBTransformer.GetOrDefault(this.SqlDataReader["ImageSource"], ""),
                Telephone = DBTransformer.GetOrDefault(this.SqlDataReader["ImageSource"], null),
                ParentUser = new FinalUser()
            };
        }

        private void CheckOrFail()
        {
            String QueryTemplate = "SELECT TOP 1 * FROM Users_Finals WHERE Id = {0}";
            String Query = String.Format(QueryTemplate, Session.user.Id);
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            this.AssertOrFail("El usuario ingresado no existe. Registrese por favor!");
        }

        private object GetUserIdOrNull(FinalUser finalUser)
        {
            try {
                return finalUser.Id;
            } catch {
                return "(NULL)";
            }
        }
    }
}
