using Domain.User;
using System;
using System.Collections.Generic;


namespace Business
{
    public class ImageRepository : Repository
    {
        public ImageRepository()
        {
            this.Table = "Media_Images";
        }
    }
}
