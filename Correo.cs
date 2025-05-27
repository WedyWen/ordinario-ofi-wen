using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ordinario_ofi_wen
{
    internal class Correo
    {
        private string remitente = "112653@alumnouninter.mx";
        private string contrasena = "Del1al12";

        public void EnviarCorreo(string destinatario)
        {
            try
            {

                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(remitente);
                mensaje.To.Add(destinatario);
                mensaje.Subject = "Correo desde la app";
                mensaje.Body = "Este es un correo enviado desde la aplicación en C#.";

                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
                smtp.Credentials = new NetworkCredential(remitente, contrasena);
                smtp.EnableSsl = true;

                smtp.Send(mensaje);
            }
            catch (Exception ex)
            {

                try
                {
                    MailMessage mensajeError = new MailMessage();
                    mensajeError.From = new MailAddress(remitente);
                    mensajeError.To.Add("112653@alumnouninter.mx");
                    mensajeError.Subject = "Error en envío de correo";
                    mensajeError.Body = $"Error al enviar correo a {destinatario}:\n\n{ex.Message}";

                    SmtpClient smtpError = new SmtpClient("smtp.office365.com", 587);
                    smtpError.Credentials = new NetworkCredential(remitente, contrasena);
                    smtpError.EnableSsl = true;

                    smtpError.Send(mensajeError);
                }
                catch (Exception ex2)
                {

                    Console.WriteLine("Error crítico al intentar enviar el correo de error: " + ex2.Message);
                }
            }



        }
    }
}
