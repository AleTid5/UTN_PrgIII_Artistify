using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Notification
    {
        public Artist Artist { set; get; }
        public FinalUser FinalUser { set; get; }
        public NotificationType NotificationType { set; get; }
        public bool WasSeen { set; get; }
        public DateTime RegisterDate { set; get; }
    }
}
