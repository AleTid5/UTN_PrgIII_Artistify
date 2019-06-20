using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NationRepository : Repository
    {
        public NationRepository()
        {
            this.Table = "Nations";
        }

        public Nation GetNation(String NationCode)
        {
            try {
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE Code = '{1}'", this.Table, NationCode);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted();
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public List<Nation> FindAll()
        {
            try {
                String Query = String.Format("SELECT * FROM {0} WHERE Status = 'A'", this.Table);
                this.ExecSelect(Query);

                List<Nation> Nations = new List<Nation>();

                while (this.SqlDataReader.Read())
                    Nations.Add(this.GetRowCasted());

                return Nations;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        private Nation GetRowCasted()
        {
            return new Nation {
                Code = Convert.ToString(this.SqlDataReader["Code"]),
                Name = Convert.ToString(this.SqlDataReader["Name"]),
                PhoneCode = int.Parse(Convert.ToString(this.SqlDataReader["PhoneCode"])),
                Status = new StatusRepository().GetStatus(Convert.ToString(this.SqlDataReader["Status"]))
            };
        }

    }
}