using Domain.User;
using System;
using System.Collections.Generic;


namespace Business
{
    public class ImageRepository : Repository
    {
        public int GetRepositoryCount()
        {
            try
            {
                String Query = String.Concat("SELECT COUNT(*) AS Image FROM TIDELE_DB.dbo.Media_Images");
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return int.Parse(this.SqlDataReader["Image"].ToString());
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
