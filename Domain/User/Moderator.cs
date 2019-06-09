using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class Moderator : AbstractUser
    {
        public Moderator(AbstractUser user = null)
        {
            if (null == user) return;

            this.Id = user.Id;
            this.Name = user.Name;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.BornDate = user.BornDate;
            this.Gender = user.Gender;
            this.Nationality = user.Nationality;
            this.Status = user.Status;
            this.RegisterDate = user.RegisterDate;
            this.LastLoginDate = user.LastLoginDate;
        }

        public Administrator Administrator { set; get; }
    }
}
