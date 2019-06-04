using Entity.User;
using System;
using System.Collections.Generic;

namespace Repository
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
                this.Administrator = this.GetCasted();
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

        public void RemoveAdmin(Administrator administrator)
        {
            try
            {
                if (this.Administrator.Id == administrator.Id)
                {
                    throw new Exception("No está autorizado para poder eliminarse a usted mismo.");
                }

                this.RemoveUser((AbstractUser) administrator);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Administrator> FindAll()
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} A INNER JOIN Users U ON A.Id = U.Id WHERE U.Status = 'A'", this.Table);
                this.ExecSelect(Query);

                List<Administrator> administrators = new List<Administrator>();

                while (this.SqlDataReader.Read())
                {
                    administrators.Add(this.GetRowCasted());
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

        private Administrator GetRowCasted()
        {
            return new Administrator
            {
                Id = Convert.ToInt32(this.SqlDataReader["Id"]),
                Name = Convert.ToString(this.SqlDataReader["Name"]),
                LastName = Convert.ToString(this.SqlDataReader["LastName"]),
                Email = Convert.ToString(this.SqlDataReader["Email"]),
                BornDate = this.GetOrNull(this.SqlDataReader["BornDate"]),
                Gender = Convert.ToChar(this.SqlDataReader["Gender"].ToString()),
                Nationality = (new NationRepository()).GetNation(Convert.ToString(this.SqlDataReader["Nationality"])),
                Status = (new StatusRepository()).GetStatus(Convert.ToString(this.SqlDataReader["Status"])),
                RegisterDate = this.GetOrNull(this.SqlDataReader["RegisterDate"]),
                LoginTimes = Convert.ToInt32(this.SqlDataReader["LoginTimes"]),
                LastLoginDate = this.GetOrNull(this.SqlDataReader["LastLoginDate"])
            };
        }

        private Administrator GetCasted()
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
