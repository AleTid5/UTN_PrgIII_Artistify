using Entity.Media;
using Entity.User;
using System;
using System.Collections.Generic;


namespace Repository
{
    public class VideoRepository : MediaRepository
    {
        public VideoRepository()
        {
            this.Table = "Media_Videos";
        }

        public void Add(Video video)
        {
            try {
                String QueryTemplate = "INSERT INTO {0} (Id) VALUES ({1})";
                String Query = String.Format(QueryTemplate, this.Table, video.Id);
                this.ExecInsert(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }
    }
}
