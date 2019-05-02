using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Media
{
    public class Music : AbstractMedia
    {
        public Album Album { set; get; }
        public int Duration { set; get; }
    }
}
