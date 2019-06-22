using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class Manager : AbstractUser
    {
        public Manager(AbstractUser abstractUser = null) : base(abstractUser) { }

        public string CUIT { set; get; }
    }
}
