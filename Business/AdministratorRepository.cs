using Common;
using Common.Senders;
using Entity.User;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class AdministratorRepository : UserRepository
    {
        public AdministratorRepository()
        {
            this.Table = "Users_Administrators";
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

        public void Add(Administrator administrator)
        {
            try {
                int lastID = this.Add((AbstractUser)administrator);
                String QueryTemplate = "INSERT INTO {0} (Id) VALUES ({1})";
                String Query = String.Format(QueryTemplate, this.Table, lastID);
                this.ExecInsert(Query);
                EmailSender.UserAdd((AbstractUser)administrator, "Administrador");
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public Administrator FindById(int Id)
        {
            try {
                String Query = String.Format("SELECT TOP 1 * FROM {0} A INNER JOIN Users U ON A.Id = U.Id WHERE U.Status = 'A' AND A.Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted() as Administrator;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public List<Administrator> FindAll()
        {
            try {
                String Query = String.Format("SELECT * FROM {0} A INNER JOIN Users U ON A.Id = U.Id", this.Table);
                this.ExecSelect(Query);

                List<Administrator> administrators = new List<Administrator>();

                while (this.SqlDataReader.Read())
                    administrators.Add(new Administrator(this.GetRowCasted()));

                return administrators;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        private void CheckOrFail()
        {
            String QueryTemplate = "SELECT TOP 1 * FROM Users_Administrators WHERE Id = {0}";
            String Query = String.Format(QueryTemplate, Session.user.Id);
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            this.AssertOrFail("El usuario ingresado no es administrador");
        }
    }
}
