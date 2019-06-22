using Common.Exceptions;
using Common.Senders;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ManagerRepository : UserRepository
    {
        public ManagerRepository()
        {
            this.Table = "Users_Managers";
        }

        public void Add(Manager manager)
        {
            try {
                int lastID = this.Add((AbstractUser)manager);
                String QueryTemplate = "INSERT INTO {0} (Id, CUIT) " +
                                       "VALUES ({1}, '{2}')";
                String Query = String.Format(QueryTemplate, this.Table,
                                                            lastID,
                                                            manager.CUIT);
                this.ExecInsert(Query);
                EmailSender.ManagerAdd(manager);
            } catch (SqlException ex) {
                throw new SqlParsedException(ex.Number, ex.Message);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public Manager FindById(int Id)
        {
            try {
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

        private Manager GetRowCasted(AbstractUser abstractUser)
        {
            return new Manager(abstractUser) {
                CUIT = this.SqlDataReader["CUIT"].ToString()
            };
        }
    }
}
