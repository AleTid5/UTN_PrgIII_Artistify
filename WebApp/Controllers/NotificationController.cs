using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        [EnableCors("allowAllOrigins")]
        public string Get()
        {

            return new Response(true).ToJson();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        [EnableCors("allowAllOrigins")]
        public string Get(int id)
        {
            return new Response(true).ToJson();
        }

        // POST: api/User
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        public string Post([FromBody] string value)
        {
            return new Response(true).ToJson();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [EnableCors("allowAllOrigins")]
        public string Put(int id, [FromBody] string value)
        {
            return new Response(true).ToJson();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("allowAllOrigins")]
        public string Delete(int id)
        {
            return new Response(true).ToJson();
        }
    }
}
