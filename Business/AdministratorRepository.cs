using Domain.User;
using System;
using System.Collections.Generic;

namespace Business
{
    public class AdministratorRepository : UserRepository
    {
        public Administrator Administrator;

        public AdministratorRepository()
        {
            this.Table = "Users_Administrators";
        }

        override
        public void AuthenticateOrFail(List<String> UserData) {
            try
            {
                this.CheckCredentialsOrFail(UserData);
                this.CheckAdministratorOrFail();
                this.Administrator = this.Casted();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
                this.UpdateUserLogin(this.Administrator.Id);
            }
        }

        public void AddAdmin(Administrator administrator)
        {
            try
            {
                int lastID = this.AddUser((AbstractUser) administrator);
                String QueryTemplate = "INSERT INTO Users_Administrators (Id) VALUES ({0})";
                String Query = String.Format(QueryTemplate, lastID);
                this.ExecInsert(Query);
            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                this.SqlConnection.Close();
            }
        }

        public void EditAdmin(Administrator administrator)
        {
            try
            {
                this.EditUser((AbstractUser) administrator);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Administrator> FindAll()
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} A INNER JOIN Users U ON A.Id = U.Id", this.Table);
                this.ExecSelect(Query);

                List<Administrator> administrators = new List<Administrator>();

                while (this.SqlDataReader.Read())
                {
                    Administrator administrator = this.GetAdministrator();
                    administrators.Add(administrator);
                }

                return administrators;
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

        private void CheckAdministratorOrFail()
        {
            String QueryTemplate = "SELECT TOP 1 * FROM Users_Administrators WHERE Id = {0}";
            String Query = String.Format(QueryTemplate, this.AbstractUser.Id);
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            this.AssertOrFail("El usuario ingresado no es administrador");
        }

        private Administrator GetAdministrator()
        {
            return new Administrator
            {
                Id = int.Parse(this.SqlDataReader["Id"].ToString()),
                Name = this.SqlDataReader["Name"].ToString(),
                LastName = this.SqlDataReader["LastName"].ToString(),
                Email = this.SqlDataReader["Email"].ToString(),
                BornDate = this.GetOrNull(this.SqlDataReader["BornDate"]),
                Gender = Convert.ToChar(this.SqlDataReader["Gender"].ToString()),
                Nationality = (new NationRepository()).GetNation(this.SqlDataReader["Nationality"].ToString()),
                Status = (new StatusRepository()).GetStatus(this.SqlDataReader["Status"].ToString()),
                RegisterDate = this.GetOrNull(this.SqlDataReader["RegisterDate"]),
                LoginTimes = int.Parse(this.SqlDataReader["LoginTimes"].ToString()),
                LastLoginDate = this.GetOrNull(this.SqlDataReader["LastLoginDate"])
            };
        }

        private Administrator Casted()
        {
            return new Administrator
            {
                Id = this.AbstractUser.Id,
                Name = this.AbstractUser.Name,
                LastName = this.AbstractUser.LastName,
                Email = this.AbstractUser.Email,
                BornDate = this.AbstractUser.BornDate,
                Gender = this.AbstractUser.Gender,
                Nationality = this.AbstractUser.Nationality,
                Status = this.AbstractUser.Status,
                RegisterDate = this.AbstractUser.RegisterDate,
                LastLoginDate = this.AbstractUser.LastLoginDate
            };
        }
    }
}
