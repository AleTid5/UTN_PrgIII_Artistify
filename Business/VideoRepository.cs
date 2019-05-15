using Domain.User;
using System;
using System.Collections.Generic;


namespace Business
{
    public class VideoRepository : Repository
    {
        public VideoRepository()
        {
            this.Table = "Media_Videos";
        }
    }
}
