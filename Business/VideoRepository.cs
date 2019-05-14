using Domain.User;
using System;
using System.Collections.Generic;


namespace Business
{
    public class VideoRepository : Repository
    {
        public int GetRepositoryCount()
        {
            try
            {
                String Query = String.Concat("SELECT COUNT(*) AS Video FROM TIDELE_DB.dbo.Media_Videos");
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return int.Parse(this.SqlDataReader["Video"].ToString());
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
