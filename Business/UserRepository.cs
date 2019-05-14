using Domain.User;
using System;
using System.Collections.Generic;


namespace Business
{
    public abstract class UserRepository : Repository
    {
        protected AbstractUser AbstractUser { set; get; }

        public abstract void AuthenticateOrFail(List<String> UserData);

        public void CheckCredentialsOrFail(List<String> UserData)
        {
            try
            {
                if (UserData[0].ToString().Trim().Equals("") || UserData[1].ToString().Equals(""))
                {
                    throw new Exception("Credenciales insuficientes");
                }

                UserData[1] = this.STR2MD5(UserData[1]);
                String QueryTemplate = "SELECT TOP 1 * FROM Users WHERE Email = '{0}' AND Password = {1}";
                String Query = String.Format(QueryTemplate, UserData[0], UserData[1]);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();
                this.AssertOrFail("Las credenciales ingresadas son incorrectas");
                this.FillUser();
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

        private void FillUser()
        {
            this.AbstractUser = new AbstractUser();
            this.AbstractUser.Id = int.Parse(this.SqlDataReader["Id"].ToString());
        }
    }
}
