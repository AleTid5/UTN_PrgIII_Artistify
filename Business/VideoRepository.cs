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
    }
}
