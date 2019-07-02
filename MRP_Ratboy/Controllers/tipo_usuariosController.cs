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
    public class tipo_usuariosController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: tipo_usuarios
        public ActionResult Index()
        {
            return View(db.tipo_usuarios.ToList());
        }

        // GET: tipo_usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuarios tipo_usuarios = db.tipo_usuarios.Find(id);
            if (tipo_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuarios);
        }

        // GET: tipo_usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,estatus")] tipo_usuarios tipo_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.tipo_usuarios.Add(tipo_usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_usuarios);
        }

        // GET: tipo_usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuarios tipo_usuarios = db.tipo_usuarios.Find(id);
            if (tipo_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuarios);
        }

        // POST: tipo_usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,estatus")] tipo_usuarios tipo_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_usuarios);
        }

        // GET: tipo_usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuarios tipo_usuarios = db.tipo_usuarios.Find(id);
            if (tipo_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuarios);
        }

        // POST: tipo_usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_usuarios tipo_usuarios = db.tipo_usuarios.Find(id);
            db.tipo_usuarios.Remove(tipo_usuarios);
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
