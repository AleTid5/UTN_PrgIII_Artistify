using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Gender
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public MediaType MediaType { set; get; }
        public Gender ParentGender { set; get; }
        public Status Status { set; get; }
    }
}
