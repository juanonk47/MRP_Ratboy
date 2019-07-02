using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.services
{
    public class ControladorEmail
    {

        public bool SendEmailForForgotePassword(Usuarios userDetails)
        {
            try
            {
                MailMessage mm = new MailMessage("desarrollo9company@gmail.com", userDetails.username);
                mm.Subject = "Verificar tu correo";
                mm.Body = string.Format("Hola : <h1>" + userDetails.username + "</h1> \n click porfavor en el enlace : <a href='https://localhost:44327/Register/RestablecerContraseña/{0}'>Click para recuperar</a>", userDetails.id);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "desarrollo9company@gmail.com";
                nc.Password = "Desarrollo9";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(mm);
                Console.WriteLine("Correo enviado");
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo mandar el correo electronico " + e.Message);
                return false;
            }
        }
    }
}