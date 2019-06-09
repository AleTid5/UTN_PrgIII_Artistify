using Entity.User;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Common.Senders
{
    public static class EmailSender
    {
        private static SmtpClient CreateSender()
        {
            return new SmtpClient("smtp.hostinger.com.ar", 587)
            {
                Credentials = new NetworkCredential()
                {
                    UserName = "info@atidele.com",
                    Password = "L+gM*ch!gws>57V&aV"
                },

                EnableSsl = true
            };
        }

        async public static void UserAdd(AbstractUser user)
        {
            MailMessage msg = new MailMessage("info@atidele.com", user.Email)
            {
                Subject = "Alta de usuario",
                IsBodyHtml = false,
                Body = "Bienvenido al sistema de administradores y moderadores de APOLLUM! Su contraseña es: " + user.Password
            };

            CreateSender().Send(msg);
        }
    }
}
