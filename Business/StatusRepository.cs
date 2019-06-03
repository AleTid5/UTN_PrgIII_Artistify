using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StatusRepository : Repository
    {
        public StatusRepository()
        {
            this.Table = "Status";
        }

        public Status GetStatus(String Code)
        {
            try
            {
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE Code = '{1}'", this.Table, Code);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted();
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

        public List<Status> FindAll()
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0}", this.Table);
                this.ExecSelect(Query);

                List<Status> statuses = new List<Status>();

                while (this.SqlDataReader.Read())
                {
                    Status status = this.GetRowCasted();
                    statuses.Add(status);
                }

                return statuses;
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

        private Status GetRowCasted()
        {
            if (!this.SqlDataReader.HasRows)
                return new Status();

            return new Status
            {
                Code = Convert.ToString(this.SqlDataReader["Code"]),
                Name = Convert.ToString(this.SqlDataReader["Name"])
            };
        }
    }
}
