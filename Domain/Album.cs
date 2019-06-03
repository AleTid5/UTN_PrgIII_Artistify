using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Album
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public Artist Artist { set; get; }
        public Status Status { set; get; }
        public DateTime RegisterDate { set; get; }
        public DateTime ModificationDate { set; get; }
    }
}
