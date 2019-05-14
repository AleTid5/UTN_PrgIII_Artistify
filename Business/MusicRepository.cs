using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class MusicRepository : Repository
    {
        public int GetRepositoryCount()
        {
            try
            {
                String Query = String.Concat("SELECT COUNT(*) AS Music FROM Media_Musics");
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return int.Parse(this.SqlDataReader["Music"].ToString());
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
