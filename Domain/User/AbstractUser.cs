using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class AbstractUser
    {
        public AbstractUser(AbstractUser abstractUser = null)
        {
            if (null == abstractUser) return;

            this.Id = abstractUser.Id;
            this.Name = abstractUser.Name;
            this.LastName = abstractUser.LastName;
            this.Email = abstractUser.Email;
            this.Password = abstractUser.Password;
            this.BornDate = abstractUser.BornDate;
            this.Gender = abstractUser.Gender;
            this.Nationality = abstractUser.Nationality;
            this.Status = abstractUser.Status;
            this.LoginTimes = abstractUser.LoginTimes;
            this.RegisterDate = abstractUser.RegisterDate;
            this.LastLoginDate = abstractUser.LastLoginDate;
        }

        public long Id { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public DateTime BornDate { set; get; }
        public char Gender { set; get; }
        public Nation Nationality { set; get; }
        public Status Status { set; get; }
        public int LoginTimes { set; get; }
        public DateTime RegisterDate { set; get; }
        public DateTime? LastLoginDate { set; get; }

        protected void Login()
        {
            this.IncrementLoginTimes();
            this.SetLastLoginDate();
        }

        private void IncrementLoginTimes()
        {
            this.LoginTimes++;
        }

        private void SetLastLoginDate()
        {
            this.LastLoginDate = new DateTime();
        }
    }
}
