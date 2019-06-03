using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class Moderator : AbstractUser
    {
        public Administrator Administrator { set; get; }
    }
}
