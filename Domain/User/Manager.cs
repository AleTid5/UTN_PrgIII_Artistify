using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class Manager : AbstractUser
    {
        public string CUIT { set; get; }
    }
}
