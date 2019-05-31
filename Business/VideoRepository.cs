using Domain.User;
using System;
using System.Collections.Generic;


namespace Repository
{
    public class VideoRepository : Repository
    {
        public VideoRepository()
        {
            this.Table = "Media_Videos";
        }
    }
}
