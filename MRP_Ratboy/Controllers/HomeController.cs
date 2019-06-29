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
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autorizacion(Usuarios usuario) {
            using (BD_ArmadoPcEntities db = new BD_ArmadoPcEntities() ) {
                var userDetails = db.Usuarios.Where(x => x.username == usuario.username && x.password == usuario.password).FirstOrDefault();
                if (userDetails == null)
                {
                    ViewBag.Error = "Usuario o contraeña incorrecta";
                    return View("Login", usuario);
                }
                else {
                    Session["usuario"] = userDetails;
                    ViewBag.Usuarios = userDetails;
                    return View("Index",userDetails);
                }
            }
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
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
    }
}
