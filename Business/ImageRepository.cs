using Entity.Media;
using Entity.User;
using System;
using System.Collections.Generic;


namespace Repository
{
    public class ImageRepository : MediaRepository
    {
        public ImageRepository()
        {
            this.Table = "Media_Images";
        }

        public void Add(Image image)
        {
            try {
                String QueryTemplate = "INSERT INTO {0} (Id) VALUES ({1})";
                String Query = String.Format(QueryTemplate, this.Table, image.Id);
                this.ExecInsert(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }
    }
}
