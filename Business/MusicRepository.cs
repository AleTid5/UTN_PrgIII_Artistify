using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MusicRepository : MediaRepository
    {
        public MusicRepository()
        {
            this.Table = "Media_Musics";
        }
    }
}
