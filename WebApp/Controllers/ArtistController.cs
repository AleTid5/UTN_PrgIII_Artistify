using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Common;
using Entity.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private new Request Request = null;

        // GET: api/Artist/5
        [HttpGet("{managerId}")]
        [EnableCors("allowAllOrigins")]
        public string Get(int managerId)
        {
            try {
                return new Response(true, new ArtistRepository().FindAllByManagerId(managerId)).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // GET: api/Artist/5/1
        [HttpGet("{managerId}/{artistId}")]
        [EnableCors("allowAllOrigins")]
        public string GetArtist(int managerId, int artistId)
        {
            try {
                return new Response(true, new ArtistRepository().FindByManagerIdAndArtistId(managerId, artistId)).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Artist
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("register")]
        public string Register([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                Artist artist = new Artist {
                    Name = this.Request.Get("name"),
                    LastName = this.Request.Get("lastname"),
                    BornDate = Convert.ToDateTime(this.Request.Get("borndate")),
                    Email = new MailAddress(this.Request.Get("email")).Address,
                    Password = this.Request.Get("password"),
                    Gender = Convert.ToChar(this.Request.Get("gender")),
                    Nationality = new NationRepository().GetNation("ARG"/*this.Request.Get("nation")*/),
                    Status = new StatusRepository().FindStatusByCode("A"),
                    Alias = this.Request.Get("alias"),
                    //ImageSource = this.Request.Get("imageSource"),
                    Manager = new ManagerRepository().FindById(Convert.ToInt32(this.Request.Get("manager")))
                };
                new ArtistRepository().Add(artist);

                return new Response(true, "Artista creado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para crear al artista.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Artist
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("edit")]
        public string Edit([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                Artist artist = new Artist {
                    Id = int.Parse(this.Request.Get("id")),
                    Name = this.Request.Get("name"),
                    LastName = this.Request.Get("lastname"),
                    BornDate = Convert.ToDateTime(this.Request.Get("borndate")),
                    Email = new MailAddress(this.Request.Get("email")).Address,
                    Gender = Convert.ToChar(this.Request.Get("gender")),
                    Nationality = new NationRepository().GetNation("ARG"/*this.Request.Get("nation")*/),
                    Status = new StatusRepository().FindStatusByCode(this.Request.Get("status")),
                    Alias = this.Request.Get("alias")
                };
                new ArtistRepository().Edit(artist);

                return new Response(true, "Artista editado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para editar al artista.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Artist/Login
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("login")]
        public string Login([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                String user = this.Request.Get("email");
                String password = this.Request.Get("password");
                new ArtistRepository().AuthenticateOrFail(user, password);

                return new Response(true, Session.user).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // DELETE: api/Artist/5
        [HttpDelete("{ArtistId}")]
        [EnableCors("allowAllOrigins")]
        public string Delete(int ArtistId)
        {
            try {
                new ArtistRepository().Remove(new AbstractUser { Id = ArtistId });
                return new Response(true).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }
    }
}
