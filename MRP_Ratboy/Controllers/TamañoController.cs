using MRP_Ratboy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MRP_Ratboy.Controllers
{
    public class TamañoController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Tamaño
        public ActionResult Index()
        {
            return View(db.Tamaño.ToList()); 
        }

        // GET: Tamaño/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamaño tamaño = db.Tamaño.Find(id);
            if (tamaño == null)
            {
                return HttpNotFound();
            }
            return View(tamaño);
        }

        // GET: Tamaño/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamaño/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTamaño,nombreTamaño,estatus")] Tamaño tamaño)
        {
            if (ModelState.IsValid)
            {
                db.Tamaño.Add(tamaño);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tamaño);
        }

        // GET: Tamaño/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamaño tamaño = db.Tamaño.Find(id);
            if (tamaño == null)
            {
                return HttpNotFound();
            }
            return View(tamaño);
        }

        // POST: Tamaño/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTamaño,nombreTamaño,estatus")] Tamaño tamaño)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tamaño).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tamaño);
        }

        // GET: Tamaño/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamaño tamaño = db.Tamaño.Find(id);
            if (tamaño == null)
            {
                return HttpNotFound();
            }
            return View(tamaño);
        }

        // POST: Tamaño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamaño tamaño = db.Tamaño.Find(id);
            db.Tamaño.Remove(tamaño);
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
