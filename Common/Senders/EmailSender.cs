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
        private static readonly string UserName = "artistify@hotmail.com";
        private static readonly string Password = "Artista123artista";

        private static SmtpClient CreateSender()
        {
            return new SmtpClient("smtp.outlook.com", 587) {
                Credentials = new NetworkCredential() {
                    UserName = UserName,
                    Password = Password
                },

                EnableSsl = true
            };
        }

        async public static void ArtistAdd(Artist user)
        {
            try {
                MailMessage msg = new MailMessage("artistify@hotmail.com", user.Email) {
                    Subject = "Alta de usuario",
                    IsBodyHtml = false,
                    Body = "Bienvenido a Artistify! Su contraseña es: " + user.Password
                };

                await CreateSender().SendMailAsync(msg);
            } catch (SmtpException) {
            } catch (Exception ex) {
                throw ex;
            }
        }

        async public static void ManagerAdd(Manager manager)
        {
            try {
                MailMessage msg = new MailMessage("artistify@hotmail.com", manager.Email) {
                    Subject = "Alta de Manager",
                    IsBodyHtml = false,
                    Body = "Bienvenido a Artistify!"
                };

                await CreateSender().SendMailAsync(msg);
            } catch (SmtpException) {
            } catch (Exception ex) {
                throw ex;
            }
        }

        async public static void UserAdd(AbstractUser user)
        {
            try {
                MailMessage msg = new MailMessage("artistify@hotmail.com", user.Email) {
                    Subject = "Alta de usuario",
                    IsBodyHtml = false,
                    Body = "Bienvenido a Artistify!"
                };

                await CreateSender().SendMailAsync(msg);
            } catch (SmtpException) {
            } catch (Exception ex) {
                throw ex;
            }
        }

        async public static void UserAdd(AbstractUser user, String userType)
        {
            try {
                MailMessage msg = new MailMessage("artistify@hotmail.com", user.Email) {
                    Subject = "Alta de usuario",
                    IsBodyHtml = false,
                    Body = "Bienvenido al sistema de " + userType + "es de Artistify! Su contraseña es: " + user.Password
                };

                await CreateSender().SendMailAsync(msg);
            } catch (SmtpException) {
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
