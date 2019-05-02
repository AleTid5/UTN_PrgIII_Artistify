using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Media
{
    public class Book : AbstractMedia
    {
        public int Pages { set; get; }
    }
}
