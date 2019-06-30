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
    public class AlbumController : ControllerBase
    {
        private new Request Request = null;

        // GET: api/Album
        [HttpGet("artist/{artistId}")]
        [EnableCors("allowAllOrigins")]
        public string GetAll(int artistId)
        {
            try {
                return new Response(true, new AlbumRepository().FindAllByArtistId(artistId)).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }
        

        // GET: api/Album/edit/5
        [HttpGet("edit/{albumId}")]
        [EnableCors("allowAllOrigins")]
        public string GetAlbumArtist(int albumId)
        {
            try {
                return new Response(true, new AlbumRepository().FindById(albumId, null)).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }
        

        // GET: api/Album/5
        [HttpGet("{albumId}")]
        [EnableCors("allowAllOrigins")]
        public string Get(int albumId)
        {
            try {
                return new Response(true, new MediaRepository().FindAllByAlbumId(albumId)).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Album/add
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("add")]
        public string Add([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                Album album = new Album {
                    Name = this.Request.Get("name"),
                    Artist = new ArtistRepository().FindById(int.Parse(this.Request.Get("artist"))),
                    ImageSource = this.Request.Get("imageSource"),
                    MediaType = new MediaTypeRepository().FindById(int.Parse(this.Request.Get("mediaType")))
                };
                new AlbumRepository().Add(album);

                return new Response(true, "Album creado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para crear al album.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Album/edit
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("edit")]
        public string Edit([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                Album album = new Album {
                    Id = int.Parse(this.Request.Get("id")),
                    Name = this.Request.Get("name"),
                    ImageSource = this.Request.Get("imageSource"),
                    MediaType = new MediaTypeRepository().FindById(int.Parse(this.Request.Get("mediaType"))),
                    Status = new StatusRepository().FindStatusByCode(this.Request.Get("status"))
                };
                new AlbumRepository().Edit(album);

                return new Response(true, "Album editado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para editar al album.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Album/remove
        [HttpDelete("{AlbumId}")]
        [EnableCors("allowAllOrigins")]
        public string Delete(int AlbumId)
        {
            try {
                new AlbumRepository().Remove(new Album { Id = AlbumId });
                return new Response(true).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }
    }
}
