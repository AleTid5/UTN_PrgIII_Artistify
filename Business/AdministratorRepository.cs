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

        public List<Administrator> FindAll()
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} A INNER JOIN Users U ON A.Id = U.Id", this.Table);
                this.ExecSelect(Query);

                List<Administrator> administrators = new List<Administrator>();

                while (this.SqlDataReader.Read())
                {
                    Administrator Nation = this.GetCasted();
                    administrators.Add(Nation);
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

        private Administrator GetCasted()
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
                LastLoginDate = this.GetOrNull(this.SqlDataReader["LastLoginDate"])
            };
        }

        private void CheckAdministratorOrFail()
        {
            String QueryTemplate = "SELECT TOP 1 * FROM Users_Administrators WHERE Id = {0}";
            String Query = String.Format(QueryTemplate, this.AbstractUser.Id);
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            this.AssertOrFail("El usuario ingresado no es administrador");
        }

        private DateTime GetOrNull(object toConvert)
        {
            try
            {
                return Convert.ToDateTime(toConvert);
            } catch (Exception)
            {
                return Convert.ToDateTime(null);
            }
        }

        private void FillAdministrator() => this.Administrator = this.AbstractUser as Administrator;
    }
}
