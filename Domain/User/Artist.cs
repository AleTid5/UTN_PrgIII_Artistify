using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class Artist : AbstractUser
    {
        public string Alias { set; get; }
        public string ImageSource { set; get; }
        public Manager Manager { set; get; }
        public MediaType ArtistType { set; get; }
        public bool Verified { set; get; }
    }
}
