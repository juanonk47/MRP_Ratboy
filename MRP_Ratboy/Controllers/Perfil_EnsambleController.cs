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
    public class Perfil_EnsambleController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Perfil_Ensamble
        public ActionResult Index()
        {
            var perfil_Ensamble = db.Perfil_Ensamble.Include(p => p.Ensamble).Include(p => p.Perfiles);
            return View(perfil_Ensamble.ToList());
        }

        // GET: Perfil_Ensamble/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil_Ensamble perfil_Ensamble = db.Perfil_Ensamble.Find(id);
            if (perfil_Ensamble == null)
            {
                return HttpNotFound();
            }
            return View(perfil_Ensamble);
        }

        // GET: Perfil_Ensamble/Create
        public ActionResult Create()
        {
            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble");
            ViewBag.idPerfil_FK = new SelectList(db.Perfiles, "idPerfil", "Nombre");
            return View();
        }

        // POST: Perfil_Ensamble/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPerfil_Ensamble,idPerfil_FK,idEnsamble_FK,nivel")] Perfil_Ensamble perfil_Ensamble)
        {
            perfil_Ensamble.estatus = true;
            if (ModelState.IsValid)
            {
                db.Perfil_Ensamble.Add(perfil_Ensamble);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble", perfil_Ensamble.idEnsamble_FK);
            ViewBag.idPerfil_FK = new SelectList(db.Perfiles, "idPerfil", "Nombre", perfil_Ensamble.idPerfil_FK);
            return View(perfil_Ensamble);
        }

        // GET: Perfil_Ensamble/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil_Ensamble perfil_Ensamble = db.Perfil_Ensamble.Find(id);
            if (perfil_Ensamble == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble", perfil_Ensamble.idEnsamble_FK);
            ViewBag.idPerfil_FK = new SelectList(db.Perfiles, "idPerfil", "Nombre", perfil_Ensamble.idPerfil_FK);
            return View(perfil_Ensamble);
        }

        // POST: Perfil_Ensamble/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPerfil_Ensamble,idPerfil_FK,idEnsamble_FK,nivel,estatus")] Perfil_Ensamble perfil_Ensamble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfil_Ensamble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble", perfil_Ensamble.idEnsamble_FK);
            ViewBag.idPerfil_FK = new SelectList(db.Perfiles, "idPerfil", "Nombre", perfil_Ensamble.idPerfil_FK);
            return View(perfil_Ensamble);
        }

        // GET: Perfil_Ensamble/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil_Ensamble perfil_Ensamble = db.Perfil_Ensamble.Find(id);
            if (perfil_Ensamble == null)
            {
                return HttpNotFound();
            }
            return View(perfil_Ensamble);
        }

        // POST: Perfil_Ensamble/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfil_Ensamble perfil_Ensamble = db.Perfil_Ensamble.Find(id);
            db.Perfil_Ensamble.Remove(perfil_Ensamble);
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
