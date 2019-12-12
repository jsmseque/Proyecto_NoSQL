using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logic.Utilitarias
{
   public class CorreoElectronico
    {
        public static bool EnviarEmail(string nombreUsuario, string correoDestinatario, string Mensaje)
        {
            string correoAdm = "nosqlproyecto2019@gmail.com";
            string claveAdm = "jsmseque999999999";
            string asunto = "Información pago";
            string body = "Saludos " + nombreUsuario + ".\n" + Mensaje + " ";

            var smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587; //587 o 25
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(correoAdm, claveAdm);
            smtp.Timeout = 20000;


            try
            {
                smtp.Send(correoAdm, correoDestinatario, asunto, body);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
