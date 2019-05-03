using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class NationRepository : Repository
    {
        public Nation getNation(String NationCode)
        {
            try
            {
                String Query = String.Concat("SELECT TOP 1 * FROM Nations WHERE Code = '", NationCode, "'");
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.Cast();
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

        public Nation getNation(int NationPhoneNumber)
        {
            try
            {
                String Query = String.Concat("SELECT TOP 1 * FROM Nations WHERE PhoneCode = ", NationPhoneNumber);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.Cast();
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

        private Nation Cast()
        {
            Nation Nation = new Nation();

            if (!this.SqlDataReader.HasRows)
            {
                Nation.Name = "No hay";
            }
            else
            {
                Nation.Code = this.SqlDataReader["Code"].ToString();
                Nation.Name = this.SqlDataReader["Name"].ToString();
                Nation.PhoneCode = int.Parse(this.SqlDataReader["PhoneCode"].ToString());
            }

            return Nation;
        }

    }
}