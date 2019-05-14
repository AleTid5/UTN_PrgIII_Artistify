using Domain.User;
using System;
using System.Collections.Generic;

namespace Business
{
    public class AdministratorRepository : UserRepository
    {
        public Administrator Administrator;

        override
        public void AuthenticateOrFail(List<String> UserData) {
            try
            {
                this.CheckCredentialsOrFail(UserData);
                this.CheckAdministratorOrFail();
                this.FillAdministrator();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
            }
        }

        public void GetUsers()
        {
            String Query =
                "SELECT * FROM Users" +
                "WHERE Id IN(SELECT Id FROM Users_Managers)" +
                "OR Id IN(SELECT Id FROM Users_Moderators)";
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            //this.AssertOrFail("El usuario ingresado no es administrador");
        }

        private void CheckAdministratorOrFail()
        {
            String QueryTemplate = "SELECT TOP 1 * FROM Users_Administrators WHERE Id = {0}";
            String Query = String.Format(QueryTemplate, this.AbstractUser.Id);
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            this.AssertOrFail("El usuario ingresado no es administrador");
        }

        private void FillAdministrator() => this.Administrator = this.AbstractUser as Administrator;
    }
}
