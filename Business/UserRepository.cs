using Common;
using Common.Exceptions;
using Common.Generator;
using Common.Senders;
using Entity.User;
using System;
using System.Collections.Generic;


namespace Repository
{
    public class UserRepository : Repository
    {
        public void AuthenticateOrFail(String Email, String Password) { }

        protected void CheckCredentialsOrFail(String Email, String Password)
        {
            try {
                if (Email.ToString().Trim().Equals("") || Password.ToString().Equals(""))
                    throw new Exception("Credenciales insuficientes");

                Password = this.STR2MD5(Password);
                String QueryTemplate = "SELECT TOP 1 * FROM Users WHERE Email = '{0}' AND Password = {1} AND Status IN ('A', 'N')";
                String Query = String.Format(QueryTemplate, Email, Password);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();
                this.AssertOrFail("Las credenciales ingresadas son incorrectas");
                Session.user = this.GetRowCasted();
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        protected void UpdateUserLogin(long? UserId)
        {
            try {
                if (null == UserId) return;
                String QueryTemplate = "UPDATE Users SET LoginTimes = LoginTimes + 1, LastLoginDate = GETDATE() WHERE Id = {0}";
                String Query = String.Format(QueryTemplate, UserId);
                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        protected int Add(AbstractUser user)
        {
            try {
                user.Password = user.Password ?? PasswordGenerator.Generate();
                String QueryTemplate = "INSERT INTO Users (Name, LastName, Email, Password, BornDate, Gender, Status, Nationality)";
                QueryTemplate += "OUTPUT INSERTED.ID VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}')";
                String Query = String.Format(QueryTemplate,
                                             user.Name,
                                             user.LastName,
                                             user.Email,
                                             this.STR2MD5(user.Password),
                                             user.BornDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                             user.Gender,
                                             user.Status.Code,
                                             user.Nationality.Code);

                return this.ExecInsert(Query); ;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void ChangePassword(String password)
        {
            try {
                String QueryTemplate = "UPDATE Users SET Password = {0}, Status = 'A' WHERE Id = {1}";
                String Query = String.Format(QueryTemplate, this.STR2MD5(password), Session.user.Id);

                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void Edit(AbstractUser user)
        {
            try {
                String QueryTemplate = "UPDATE Users SET Name = '{0}', LastName = '{1}', Email = '{2}', BornDate = '{3}', Gender = '{4}', Nationality = '{5}', Status = '{6}' WHERE Id = {7}";
                String Query = String.Format(QueryTemplate,
                                             user.Name,
                                             user.LastName,
                                             user.Email,
                                             user.BornDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                             user.Gender,
                                             user.Nationality.Code,
                                             user.Status.Code,
                                             user.Id);

                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void Remove(AbstractUser user)
        {
            try {
                if (Session.user.Id == user.Id)
                    throw new Exception("No está autorizado para poder eliminarse a usted mismo.");

                String Query = String.Format("UPDATE Users SET Status = 'B' WHERE Id = {0}", user.Id);

                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public List<AbstractUser> FindAll(List<String> joins)
        {
            try {
                this.Table = "Users";
                string leftJoin = "";
                foreach (String join in joins) leftJoin += "LEFT JOIN Users_" + join + " ON A.Id = Users_" + join + ".Id ";

                String Query = String.Format("SELECT * FROM {0} A " + leftJoin, this.Table);
                this.ExecSelect(Query);

                List<AbstractUser> users = new List<AbstractUser>();

                while (this.SqlDataReader.Read())
                    users.Add(this.GetRowCasted());

                return users;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        protected AbstractUser GetRowCasted()
        {
            if (!this.SqlDataReader.HasRows)
                throw new SqlParsedException(100);

            return new AbstractUser {
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
    }
}
