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
    }
}
