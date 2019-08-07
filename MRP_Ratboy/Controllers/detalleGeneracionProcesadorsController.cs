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
    public class detalleGeneracionProcesadorsController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: detalleGeneracionProcesadors
        public ActionResult Index()
        {
            return View(db.detalleGeneracionProcesador.ToList());
        }

        // GET: detalleGeneracionProcesadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleGeneracionProcesador detalleGeneracionProcesador = db.detalleGeneracionProcesador.Find(id);
            if (detalleGeneracionProcesador == null)
            {
                return HttpNotFound();
            }
            return View(detalleGeneracionProcesador);
        }

        // GET: detalleGeneracionProcesadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: detalleGeneracionProcesadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGeneracionProcesador,DetalleGeneracionProcesador1,estatus")] detalleGeneracionProcesador detalleGeneracionProcesador)
        {
            if (ModelState.IsValid)
            {
                detalleGeneracionProcesador.estatus = true;
                db.detalleGeneracionProcesador.Add(detalleGeneracionProcesador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalleGeneracionProcesador);
        }

        // GET: detalleGeneracionProcesadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleGeneracionProcesador detalleGeneracionProcesador = db.detalleGeneracionProcesador.Find(id);
            if (detalleGeneracionProcesador == null)
            {
                return HttpNotFound();
            }
            return View(detalleGeneracionProcesador);
        }

        // POST: detalleGeneracionProcesadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGeneracionProcesador,DetalleGeneracionProcesador1,estatus")] detalleGeneracionProcesador detalleGeneracionProcesador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleGeneracionProcesador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalleGeneracionProcesador);
        }

        // GET: detalleGeneracionProcesadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleGeneracionProcesador detalleGeneracionProcesador = db.detalleGeneracionProcesador.Find(id);
            if (detalleGeneracionProcesador == null)
            {
                return HttpNotFound();
            }
            return View(detalleGeneracionProcesador);
        }

        // POST: detalleGeneracionProcesadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalleGeneracionProcesador detalleGeneracionProcesador = db.detalleGeneracionProcesador.Find(id);
            db.detalleGeneracionProcesador.Remove(detalleGeneracionProcesador);
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
