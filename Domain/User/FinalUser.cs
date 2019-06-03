using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class FinalUser : AbstractUser
    {
        public string ImageSource { set; get; }
        public string Telephone { set; get; }
        public FinalUser ParentUser { set; get; }
    }
}
