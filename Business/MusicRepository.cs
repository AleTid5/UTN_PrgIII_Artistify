using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class MusicRepository : Repository
    {
       public MusicRepository()
        {
            this.Table = "Media_Musics";
        }
    }
}
