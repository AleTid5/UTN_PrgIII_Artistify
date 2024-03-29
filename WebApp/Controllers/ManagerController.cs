﻿using System;
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
    public class ManagerController : ControllerBase
    {
        private new Request Request = null;

        // POST: api/Manager
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("register")]
        public string Register([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                Manager manager = new Manager {
                    Name = this.Request.Get("name"),
                    LastName = this.Request.Get("lastname"),
                    BornDate = Convert.ToDateTime(this.Request.Get("borndate")),
                    Email = new MailAddress(this.Request.Get("email")).Address,
                    Password = this.Request.Get("password"),
                    Gender = Convert.ToChar(this.Request.Get("gender")),
                    Nationality = new NationRepository().GetNation("ARG"/*this.Request.Get("nation")*/),
                    Status = new StatusRepository().FindStatusByCode("A"),
                    CUIT = this.Request.Get("cuit")
                };
                new ManagerRepository().Add(manager);

                return new Response(true, "Usuario creado exitosamente!").ToJson();
            } catch (NullReferenceException) {
                return new Response(false, "No se han enviado todos los parametros necesarios para crear al manager.").ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // POST: api/Manager/login
        [HttpPost]
        [EnableCors("allowAllOrigins")]
        [Route("login")]
        public string Login([FromForm] string json)
        {
            try {
                this.Request = new Request(json);
                String user = this.Request.Get("email");
                String password = this.Request.Get("password");
                new ManagerRepository().AuthenticateOrFail(user, password);

                return new Response(true, Session.user).ToJson();
            } catch (Exception ex) {
                return new Response(false, ex.Message).ToJson();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
