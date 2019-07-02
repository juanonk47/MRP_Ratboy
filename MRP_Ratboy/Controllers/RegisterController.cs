using MRP_Ratboy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using System.Net;
using MRP_Ratboy.services;

namespace MRP_Ratboy.Controllers
{
    
    public class RegisterController : Controller
    {
        //CONTROLADOR PARA EL REGISTRO DEL USUARIO CLIENTE
        private ControladorUsuariosBD cu = new ControladorUsuariosBD();
        private ControladorEmail ce = new ControladorEmail();
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();
        // GET: Register
        public ActionResult Create()
        {
            return check_session("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,password")] Usuarios usuarios)
        {
            usuarios.estatus = 0;
            usuarios.tipo_id = 1;
            
            if (ModelState.IsValid)
            {
                //Mandar correo para el registro
                var checkuser = db.Usuarios.Where(x => x.username == usuarios.username).FirstOrDefault();
                if (checkuser != null)
                {
                    ViewBag.Error = "Ya existe un registro con ese correo electronico";
                    return View(usuarios);
                }
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                var userDetails = db.Usuarios.Where(x => x.username == usuarios.username && x.password == usuarios.password).FirstOrDefault();
                try
                {
                    MailMessage mm = new MailMessage("desarrollo9company@gmail.com", userDetails.username);
                    mm.Subject = "Verificar tu correo";
                    mm.Body = string.Format("Hola : <h1>" + userDetails.username + "</h1> \n click porfavor en el enlace : <a href='https://localhost:44327/Register/registro/{0}'>Click para registrar</a>", userDetails.id);
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

                }catch(Exception e) {
                    Console.WriteLine("No se pudo mandar el correo electronico "+e.Message);
                    ViewBag.Error = "No se pudo enviar el correo electronico "+e.Message;
                    return RedirectToAction("Login", "Home");
                }
                return RedirectToAction("Login");
            }

            return View(usuarios);
        }
        public ActionResult check_session(string pagina)
        {
            Usuarios user = (Usuarios)Session["usuario"];
            if (user == null)
            {
                return View(pagina);
            }
            else
            {
                ViewBag.Error = "No se pueden registrar cuando no te has deslogeado";
                return RedirectToAction("Index",user);
            }
        }
        [HttpGet]
        public ActionResult registro(int id)
        {
            var userDetail = cu.ValidarCorreo(id);
            if (userDetail != null)
            {
                return RedirectToAction("Login", "Home",userDetail);
            }
            ViewBag.Error = "Registro errorneo por favor contactar a soporte";
            return View();
        }
        public ActionResult Verificar()
        {
            
            return View();
        }
        public ActionResult RecuperarContraseña()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecuperarContraseña(Usuarios usuarios)
        {
            try
            {
                var userDetails = db.Usuarios.Where(x => x.username == usuarios.username).FirstOrDefault();
                if (ce.SendEmailForForgotePassword(userDetails))
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ViewBag.Error = "No se pudo enviar el correo de restablecimiento";
                    return View();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.Error = e.Message;
                return View();
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult RestablecerContraseña(Usuarios user)
        {
            //Actualizamos la contraseña del usuario
            
            if (user != null)
            {
                cu.UpdateUsuario(user);
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Error = "No se pudo encontrar el usuario";
            return View("RecuperarContraseña");
        }
        [HttpGet]
        public ActionResult RestablecerContraseña(int id)
        {
            //Actualizamos la contraseña del usuario
            var user = db.Usuarios.Find(id);
            if (user != null)
            {
                return View(user);
            }
            ViewBag.Error = "No se pudo encontral el usuario";
            return View("RecuperarContraseña");
        }

    }
}