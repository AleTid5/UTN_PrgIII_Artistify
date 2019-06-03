using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Media
{
    public class Video : AbstractMedia
    {
        public Album Album { set; get; }
        public int Duration { set; get; }
    }
}
