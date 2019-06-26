using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        // GET: api/Media/5
        [HttpGet("{mediaType}")]
        [EnableCors("allowAllOrigins")]
        public string Get(int mediaType)
        {
            try {
                return new Response(true, new AlbumRepository().FindAllByMediaType(mediaType)).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Media
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        public string Post([FromBody] string value)
        {
            return new Response(true).ToJson();
        }

        // PUT: api/Media/5
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
