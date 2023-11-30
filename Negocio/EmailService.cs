using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient("smtp.gmail.com", 587);
            server.Credentials = new NetworkCredential("superprendasprogramacion@gmail.com", "fkdlwwvtaxeflezj");
            server.EnableSsl = true;
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@superprendas.net");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void RecibirCorreo(string remitente, string nombre, string apellido, string telefono, string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("casilladecontacto@superprendas.net");
            email.To.Add("superprendasprogramacion@gmail.com");
            email.Subject = "Contacto de usuario";
            email.IsBodyHtml = true;
            email.Body = "<h4>Apellido y nombre de contacto: </h4>" + nombre + " " + apellido + " " + "<h4>Datos de contacto: </h4>" + telefono + " " + remitente + "<h4>Mensaje: </h4> " + mensaje;
        }

        public void EnviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
