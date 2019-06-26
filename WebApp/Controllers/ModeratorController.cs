using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeratorController : ControllerBase
    {
        private new Request Request = null;

        // GET: api/Moderator/login
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("login")]
        public string Login([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                String user = this.Request.Get("email");
                String password = this.Request.Get("password");
                new ModeratorRepository().AuthenticateOrFail(user, password);

                return new Response(true, Session.user).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
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
