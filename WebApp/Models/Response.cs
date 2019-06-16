using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Response
    {
        public object Data { set; get; }
        public bool Status { set; get; }

        public Response(bool Status, object Data = null)
        {
            this.Status = Status;
            this.Data = Data;
        }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
