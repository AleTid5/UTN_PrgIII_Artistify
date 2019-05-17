﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
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

                return this.GetCasted();
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

        private Status GetCasted()
        {
            return new Status
            {
                Code = Convert.ToString(this.SqlDataReader["Code"]),
                Name = Convert.ToString(this.SqlDataReader["Name"])
            };
        }
    }
}