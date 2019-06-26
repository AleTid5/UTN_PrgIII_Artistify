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
        private new Request Request = null;

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
        [Route("contentReproduced")]
        public void ContentReproduced([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                int mediaId = Convert.ToInt32(this.Request.Get("mediaId"));
                new MediaRepository().AddReproducedTime(mediaId);
            } catch { }
        }

        // POST: api/Media
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("setRating")]
        public void SetRating([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                int userId = Convert.ToInt32(this.Request.Get("userId"));
                int mediaId = Convert.ToInt32(this.Request.Get("mediaId"));
                int rating = Convert.ToInt32(this.Request.Get("rating"));
                new MediaRepository().SetRating(userId, mediaId, rating);
            } catch { }
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
