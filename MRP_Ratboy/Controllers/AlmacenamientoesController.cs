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
    public class AlmacenamientoesController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Almacenamientoes
        public ActionResult Index()
        {
            return View(db.Almacenamiento.ToList());
        }

        // GET: Almacenamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamiento.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // GET: Almacenamientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Almacenamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlmacenamento,nombre,tipo,capacidad,costoProveedor,costoVenta,estatus,marca,rpm")] Almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Almacenamiento.Add(almacenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(almacenamiento);
        }

        // GET: Almacenamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamiento.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // POST: Almacenamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlmacenamento,nombre,tipo,capacidad,costoProveedor,costoVenta,estatus,marca,rpm")] Almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(almacenamiento);
        }

        // GET: Almacenamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamiento.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // POST: Almacenamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Almacenamiento almacenamiento = db.Almacenamiento.Find(id);
            db.Almacenamiento.Remove(almacenamiento);
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
