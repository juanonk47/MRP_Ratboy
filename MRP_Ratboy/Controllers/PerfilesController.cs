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
    public class PerfilesController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Perfiles
        public ActionResult Index()
        {
            return View(db.Perfiles.ToList());
        }

        // GET: Perfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // GET: Perfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPerfil,Nombre,Nivel,idEnsamble_FK,estatus")] Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                db.Perfiles.Add(perfiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfiles);
        }

        // GET: Perfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: Perfiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPerfil,Nombre,Nivel,idEnsamble_FK,estatus")] Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfiles);
        }

        // GET: Perfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: Perfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfiles perfiles = db.Perfiles.Find(id);
            db.Perfiles.Remove(perfiles);
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
