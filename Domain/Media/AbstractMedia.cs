using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Media
{
    public class AbstractMedia
    {
        public long Id { set; get; }
        public Artist Artist { set; get; }
        public string Name { set; get; }
        public decimal Rating { set; get; }
        public Gender Gender { set; get; }
        public Category Category { set; get; }
        public Status Status { set; get; }
        public string Size { set; get; }
        public long ReproducedTimes { set; get; }
        public DateTime RegisterDate { set; get; }     
    }
}
