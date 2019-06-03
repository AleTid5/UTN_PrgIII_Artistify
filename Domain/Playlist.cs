using Entity;
using Entity.User;
using Entity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Playlist
    {
        public long Id { set; get; }
        public FinalUser Creator { set; get; }
        public MediaType MediaType { set; get; }
        public List<AbstractMedia> AddedMedia { set; get; }
        public List<FinalUser> AssociatedUsers { set; get; }
        public Status Status { set; get; }
        public DateTime RegisterDate { set; get; }
        public DateTime ModificationDate { set; get; }
    }
}
