using Domain.User;
using System;
using System.Collections.Generic;


namespace Business
{
    public class BookRepository : Repository
    {
        public int GetRepositoryCount()
        {
            try
            {
                String Query = String.Concat("SELECT COUNT(*) AS Book FROM TIDELE_DB.dbo.Media_Books");
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return int.Parse(this.SqlDataReader["Book"].ToString());
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
    }
}
