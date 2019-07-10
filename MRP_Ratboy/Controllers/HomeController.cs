using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.Controllers
{
    public class HomeController : Controller
    {
        // Session["usuario"] Esta es la variable que se le da al usuario cuando se logea exitosamente
        // GET: Home
        public ActionResult Index()
        {
           return  check_session("Index");
           
        }
        public ActionResult Login()
        {
            Session["usuario"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Autorizacion(Usuarios usuario) {
            //CHECAR EL REGISTRO DEL CORREO ELECTRONICO
            using (BD_ArmadoPcEntities db = new BD_ArmadoPcEntities() ) {
                var userDetails = db.Usuarios.Where(x => x.username == usuario.username && x.password == usuario.password).FirstOrDefault();
                if (userDetails == null)
                {
                    ViewBag.Error = "Usuario o contraeña incorrecta";
                    return View("Login", usuario);
                }
                else {
                    //Cambiar estatus por tabla de verificado
                    if (userDetails.estatus == 0)
                    {
                        return RedirectToAction("Verificar", "Register",userDetails);
                    }
                    Session["usuario"] = userDetails;
                    ViewBag.Usuarios = userDetails;
                    return View("Index",userDetails);
                }
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return check_session("Create");
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult check_session(string pagina)
        {
            Usuarios user = (Usuarios)Session["usuario"];
            if (user != null)
            {
                return View(pagina,user);
            }
            else
            {
                ViewBag.Error = "No se puede acceder sin antes iniciar session";
                return View("Login");
            }
        }
        public bool check_session_bolean()
        {
            Usuarios user = (Usuarios)Session["usuario"];
            if (user == null) {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
