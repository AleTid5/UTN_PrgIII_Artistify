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
        public NationRepository()
        {
            this.Table = "Nations";
        }

        public Nation GetNation(String NationCode)
        {
            try
            {
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE Code = '{1}'", this.Table, NationCode);
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

        public Nation GetNation(int NationPhoneNumber)
        {
            try
            {
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE PhoneCode = {1}", this.Table, NationPhoneNumber);
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

        public List<Nation> FindAll()
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE Status = 'A'", this.Table);
                this.ExecSelect(Query);

                List<Nation> Nations = new List<Nation>();

                while (this.SqlDataReader.Read())
                {
                    Nation Nation = this.GetCasted();
                    Nations.Add(Nation);
                }

                return Nations;
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

        private Nation GetCasted()
        {
            Nation Nation = new Nation();

            if (!this.SqlDataReader.HasRows)
            {
                Nation.Name = "No se ha encontrado";
            }
            else
            {
                Nation.Code = this.SqlDataReader["Code"].ToString();
                Nation.Name = this.SqlDataReader["Name"].ToString();
                Nation.PhoneCode = int.Parse(this.SqlDataReader["PhoneCode"].ToString());
                Nation.Status = (new StatusRepository()).GetStatus(this.SqlDataReader["Status"].ToString());
            }

            return Nation;
        }

    }
}