using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.Controllers
{
    [Authorize]
    public class UsuariosAdminsController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: UsuariosAdmins
        public ActionResult Index()
        {
            var usuariosAdmin = db.UsuariosAdmin.Include(u => u.Persona).Include(u => u.UserRole);
            return View(usuariosAdmin.ToList());
        }

        // GET: UsuariosAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            if (usuariosAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuariosAdmin);
        }

        // GET: UsuariosAdmins/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombre");
            ViewBag.idRol = new SelectList(db.UserRole, "idRol", "nombre");
            return View();
        }

        // POST: UsuariosAdmins/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUserAdmin,idPersona,idRol,correo,password,status")] UsuariosAdmin usuariosAdmin)
        {
            if (ModelState.IsValid)
            {
                db.UsuariosAdmin.Add(usuariosAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombre", usuariosAdmin.idPersona);
            ViewBag.idRol = new SelectList(db.UserRole, "idRol", "nombre", usuariosAdmin.idRol);
            return View(usuariosAdmin);
        }

        // GET: UsuariosAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            if (usuariosAdmin == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombre", usuariosAdmin.idPersona);
            ViewBag.idRol = new SelectList(db.UserRole, "idRol", "nombre", usuariosAdmin.idRol);
            return View(usuariosAdmin);
        }

        // POST: UsuariosAdmins/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUserAdmin,idPersona,idRol,correo,password,status")] UsuariosAdmin usuariosAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombre", usuariosAdmin.idPersona);
            ViewBag.idRol = new SelectList(db.UserRole, "idRol", "nombre", usuariosAdmin.idRol);
            return View(usuariosAdmin);
        }

        // GET: UsuariosAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            if (usuariosAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuariosAdmin);
        }

        // POST: UsuariosAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            db.UsuariosAdmin.Remove(usuariosAdmin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
