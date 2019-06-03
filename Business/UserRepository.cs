using Entity.User;
using System;
using System.Collections.Generic;


namespace Repository
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
                String QueryTemplate = "SELECT TOP 1 * FROM Users WHERE Email = '{0}' AND Password = {1} AND Status = 'A'";
                String Query = String.Format(QueryTemplate, UserData[0], UserData[1]);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();
                this.AssertOrFail("Las credenciales ingresadas son incorrectas");
                this.AbstractUser = this.UserCasted();
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

        public void UpdateUserLogin(long? UserId)
        {
            try
            {
                if (null == UserId) return;
                String QueryTemplate = "UPDATE Users SET LoginTimes = LoginTimes + 1, LastLoginDate = GETDATE() WHERE Id = {0}";
                String Query = String.Format(QueryTemplate, UserId);
                this.ExecUpdate(Query);
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

        public int AddUser(AbstractUser user)
        {
            try
            {
                String QueryTemplate = "INSERT INTO Users (Name, LastName, Email, Password, BornDate, Gender, Nationality)";
                QueryTemplate += "OUTPUT INSERTED.ID VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}')";
                String Query = String.Format(QueryTemplate,
                                             user.Name,
                                             user.LastName,
                                             user.Email,
                                             this.STR2MD5(user.Password),
                                             user.BornDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                             user.Gender,
                                             user.Nationality.Code);

                return this.ExecInsert(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                this.SqlConnection.Close();
            }
        }

        public void EditUser(AbstractUser user)
        {
            try
            {
                String QueryTemplate = "UPDATE Users SET Name = '{0}', LastName = '{1}', Email = '{2}', BornDate = '{3}', Gender = '{4}', Nationality = '{5}' WHERE Id = {6}";
                String Query = String.Format(QueryTemplate,
                                             user.Name,
                                             user.LastName,
                                             user.Email,
                                             user.BornDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                             user.Gender,
                                             user.Nationality.Code,
                                             user.Id);

                this.ExecUpdate(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                this.SqlConnection.Close();
            }
        }

        public void RemoveUser(AbstractUser user)
        {
            try
            {
                String QueryTemplate = "UPDATE Users SET Status = 'B' WHERE Id = {0}";
                String Query = String.Format(QueryTemplate, user.Id);

                this.ExecUpdate(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                this.SqlConnection.Close();
            }
        }

        protected AbstractUser UserCasted()
        {
            return new AbstractUser
            {
                Id = int.Parse(this.SqlDataReader["Id"].ToString()),
                Name = this.SqlDataReader["Name"].ToString(),
                LastName = this.SqlDataReader["LastName"].ToString(),
                Email = this.SqlDataReader["Email"].ToString(),
                BornDate = this.GetOrNull(this.SqlDataReader["BornDate"]),
                Gender = Convert.ToChar(this.SqlDataReader["Gender"].ToString()),
                Nationality = (new NationRepository()).GetNation(this.SqlDataReader["Nationality"].ToString()),
                Status = (new StatusRepository()).GetStatus(this.SqlDataReader["Status"].ToString()),
                LoginTimes = int.Parse(this.SqlDataReader["LoginTimes"].ToString()),
                RegisterDate = this.GetOrNull(this.SqlDataReader["RegisterDate"]),
                LastLoginDate = this.GetOrNull(this.SqlDataReader["LastLoginDate"])
            };
        }

        protected DateTime GetOrNull(object toConvert)
        {
            try
            {
                return Convert.ToDateTime(toConvert);
            }
            catch (Exception)
            {
                return Convert.ToDateTime(null);
            }
        }
    }
}
