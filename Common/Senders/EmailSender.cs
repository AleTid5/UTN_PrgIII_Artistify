using Entity.User;
using System;
using System.Net;
using System.Net.Mail;

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
                    Subject = "Artistify | Registro exitoso de Artista",
                    IsBodyHtml = true,
                    Body = GetBody("7C0h7Fs/Artistify-Artist")
                };

                msg.Body += "Su contraseña es: " + user.Password;

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
                    Subject = "Artistify | Registro exitoso de Manager",
                    IsBodyHtml = true,
                    Body = GetBody("QH5RSYH/Artistify-Manager")
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
                    Subject = "Artistify | Registro exitoso!",
                    IsBodyHtml = true,
                    Body = GetBody("kGP5JmT/Artistify-Final-User")
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
                    Subject = "Artistify | Registro exitoso de " + userType,
                    IsBodyHtml = true,
                    Body = GetBody("Administrador" == userType ? "vszGwYj/Artistify-Admin" : "pJwz0W2/Artistify-Moderator")
                };

                msg.Body += "Su contraseña es: " + user.Password;

                await CreateSender().SendMailAsync(msg);
            } catch (SmtpException) {
            } catch (Exception ex) {
                throw ex;
            }
        }

        private static string GetBody(string type)
        {
            return
                "<!DOCTYPE html>" +
                "<html>" +
                "<body>" +
                "<table>" +
                "	<tr>" +
                "		<img src='https://i.ibb.co/" + type + ".jpg'>" +
                "	</tr>" +
                "</table>" +
                "</body>" +
                "</html>";
        }
    }
}
