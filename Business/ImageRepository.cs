using Entity.User;
using System;
using System.Collections.Generic;


namespace Repository
{
    public class ImageRepository : Repository
    {
        public ImageRepository()
        {
            this.Table = "Media_Images";
        }
    }
}
