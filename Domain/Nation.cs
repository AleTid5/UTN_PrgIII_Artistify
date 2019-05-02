using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Nation
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string PhoneCode { set; get; }
        public Status Status { set; get; }
    }
}
