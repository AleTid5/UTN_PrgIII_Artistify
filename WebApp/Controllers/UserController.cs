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
    public class UserController : ControllerBase
    {
        private new Request Request = null;

        // GET: api/User/5
        [HttpGet("{id}")]
        [EnableCors("allowAllOrigins")]
        public string Get(int id)
        {
            try {
                return new Response(true, new FinalUserRepository().FindById(id)).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/User
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        public string ValidateUser([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                String user = this.Request.Get("email");
                String password = this.Request.Get("password");
                new FinalUserRepository().AuthenticateOrFail(user, password);

                return new Response(true, Session.user).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/User
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("register")]
        public string RegisterUser([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                FinalUser finalUser = new FinalUser {
                    Name = this.Request.Get("name"),
                    LastName = this.Request.Get("lastname"),
                    BornDate = Convert.ToDateTime(this.Request.Get("borndate")),
                    Email = new MailAddress(this.Request.Get("email")).Address,
                    Password = this.Request.Get("password"),
                    Gender = Convert.ToChar(this.Request.Get("gender")),
                    ImageSource = this.Request.Get("imageSource"),
                    Nationality = new NationRepository().GetNation(this.Request.Get("nation")),
                    Telephone = this.Request.Get("telephone"),
                    Status = new StatusRepository().GetStatus("A"),
                    ParentUser = new FinalUserRepository().FindById(Convert.ToInt32(this.Request.GetOrNull("parentUserId"))),                    
                };
                new FinalUserRepository().Add(finalUser);

                return new Response(true, "Usuario creado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para crear al usuario.").ToJson();
            }catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("allowAllOrigins")]
        public string Delete(int id)
        {
            try {
                return new Response(true, null).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }
    }
}
