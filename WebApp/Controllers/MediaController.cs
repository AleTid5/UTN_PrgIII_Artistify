using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entity;
using Entity.Media;
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



        // POST: api/Media/add
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("add")]
        public string Add([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                HttpRequest httpRequest = HttpContext.Request;
                int mediaType = int.Parse(this.Request.Get("mediaType"));
                Dictionary<String, String> fileData = this.Request.GetValidatedFile(httpRequest, mediaType);

                AbstractMedia media = new AbstractMedia {
                    Name = this.Request.Get("name"),
                    Album = new AlbumRepository().FindById(int.Parse(this.Request.Get("album"))),
                    Gender = new GenderRepository().FindById(int.Parse(this.Request.Get("gender"))),
                    Category = new CategoryRepository().FindById(int.Parse(this.Request.Get("category"))),
                    Size = fileData["fileSize"],
                    Source = fileData["fileDestination"]
                };
                int Id = new MediaRepository().Add(media);

                switch (mediaType) {
                    case 1: // Musica
                        new MusicRepository().Add(new Music() { Id = Id });
                        break;
                    case 2: // Video
                        new VideoRepository().Add(new Video() { Id = Id });
                        break;
                    case 3: // Libro
                        new BookRepository().Add(new Book() { Id = Id });
                        break;
                    case 4: // Imagen
                        new ImageRepository().Add(new Image() { Id = Id });
                        break;
                }

                return new Response(true, "Contenido creado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para crear el contenido.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Media/edit
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("edit")]
        public string Edit([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                HttpRequest httpRequest = HttpContext.Request;
                int mediaType = int.Parse(this.Request.Get("mediaType"));
                Dictionary<String, String> fileData = this.Request.GetValidatedFile(httpRequest, mediaType);

                AbstractMedia media = new AbstractMedia {
                    Name = this.Request.Get("name"),
                    Album = new AlbumRepository().FindById(int.Parse(this.Request.Get("album"))),
                    Gender = new GenderRepository().FindById(int.Parse(this.Request.Get("gender"))),
                    Category = new CategoryRepository().FindById(int.Parse(this.Request.Get("category"))),
                    Status = new StatusRepository().FindStatusByCode(this.Request.Get("status")),
                    Size = fileData["fileSize"],
                    Source = fileData["fileDestination"]
                };
                new MediaRepository().Add(media);

                return new Response(true, "Contenido editado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para editar el contenido.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Media/remove
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("remove")]
        public string Remove([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                AbstractMedia media = new AbstractMedia {
                    Id = int.Parse(this.Request.Get("id"))
                };
                new MediaRepository().Remove(media);

                return new Response(true, "Album eliminado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para eliminar al album.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }
    }
}
