using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Status
    {
        public string Code { set; get; }
        public string Name { set; get; }

        override
        public String ToString()
        {
            return null == this.Name ? "anda a saber" : this.Name.ToString();
        }
    }
}
