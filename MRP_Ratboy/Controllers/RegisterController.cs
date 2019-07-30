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
        public ActionResult Create([Bind(Include = "username,password,nombre,apeMaterno,apePaterno,direccion,edad")] EUsuarioPersona eUsuarioPersona)
        {
            Usuarios usuario = new Usuarios();
            Persona persona = new Persona();
            correoElectronico correoElectronico = new correoElectronico();
            //Primero tiene que crear a la persona luego al usuario y generar el campo de registro
            if (ModelState.IsValid)
            {
                //Mandar correo para el registro
                var checkuser = db.Usuarios.Where(x => x.username == eUsuarioPersona.username).FirstOrDefault();
                if (checkuser != null)
                {
                    ViewBag.Error = "Ya existe un registro con ese correo electronico";
                    return View(eUsuarioPersona);
                }

                persona.nombre = eUsuarioPersona.nombre;
                persona.estatus = true;
                persona.edad = eUsuarioPersona.edad;
                persona.direccion = eUsuarioPersona.direccion;
                persona.apePaterno = eUsuarioPersona.apePaterno;
                persona.apeMaterno = eUsuarioPersona.apeMaterno;
                db.Persona.Add(persona);
                db.SaveChanges();

                usuario.username = eUsuarioPersona.username;
                usuario.tipo_id_FK = 1;
                usuario.password = eUsuarioPersona.password;
                usuario.idPersona_FK = persona.idPersona;
                usuario.estatus = 0;
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                Random r = new Random();
                int aleatorio = r.Next(1, 10000000);
                correoElectronico.campoAutogenerado = aleatorio;
                correoElectronico.fecha = DateTime.Now;
                correoElectronico.idUsuario_FK = usuario.idUsuario;
                correoElectronico.estatus = true;
                db.correoElectronico.Add(correoElectronico);
                db.SaveChanges();
                //var userDetails = db.Usuarios.Where(x => x.username == usuarios.username && x.password == usuarios.password).FirstOrDefault();

                try
                {
                    MailMessage mm = new MailMessage("desarrollo9company@gmail.com", usuario.username);
                    mm.Subject = "Verificar tu correo";
                    mm.Body = string.Format("Hola : <h1>" + usuario.username + "</h1> \n click porfavor en el enlace : <a href='https://localhost:44327/Register/registro/{0}'>Click para registrar</a>", correoElectronico.campoAutogenerado);
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
                return RedirectToAction("Login","Home");
            }

            return View(eUsuarioPersona);
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
                
                if (userDetails != null) {
                    
                    var correo = db.correoElectronico.Where(x => x.idUsuario_FK == userDetails.idUsuario).FirstOrDefault();
                    if (correo != null)
                    {
                        if (ce.SendEmailForForgotePassword(userDetails, correo.campoAutogenerado))
                        {
                            return RedirectToAction("Login", "Home");
                        }
                        else
                        {
                            ViewBag.Error = "No se pudo enviar el correo de restablecimiento";
                            return View();
                        }
                    }
                }
                ViewBag.Error = "No se encontro el usuario";
                
                return View();
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
                cu.UpdateUsuarioPassword(user);
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Error = "No se pudo encontrar el usuario";
            return View("RecuperarContraseña");
        }
        [HttpGet]
        public ActionResult RestablecerContraseña(int id)
        {
            //Actualizamos la contraseña del usuario
            var correo = db.correoElectronico.Where(x => x.campoAutogenerado == id).FirstOrDefault();
            if (correo != null)
            {

                return View(correo.Usuarios);
            }
            ViewBag.Error = "No se pudo encontral el usuario";
            return View("RecuperarContraseña");
        }

    }
}