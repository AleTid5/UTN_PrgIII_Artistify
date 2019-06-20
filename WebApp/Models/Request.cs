using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Request
    {
        private JToken ParsedObject = null;

        public Request(string Json, string key = "form")
        {
            this.ParsedObject = JObject.Parse(Json)[key];
        }

        public String Get(String key)
        {
            return ((String) this.ParsedObject[key]).Trim();
        }

        public String GetOrNull(String key)
        {
            try {
                return ((String)this.ParsedObject[key]).Trim();
            } catch (NullReferenceException) {
                return null;
            }
        }
    }
}
