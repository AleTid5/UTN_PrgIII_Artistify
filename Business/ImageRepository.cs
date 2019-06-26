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
    }
}
