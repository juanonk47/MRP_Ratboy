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
    public class AlmacenamientoController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Almacenamiento
        public ActionResult Index()
        {
            var almacenamiento = db.Almacenamiento.Include(a => a.Marca1).Include(a => a.TipoAlmacenamiento);
            return View(almacenamiento.ToList());
        }

        // GET: Almacenamiento/Details/5
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

        // GET: Almacenamiento/Create
        public ActionResult Create()
        {
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre");
            ViewBag.tipo = new SelectList(db.TipoAlmacenamiento, "idTipoAlmacenamiento", "nombre");
            return View();
        }

        // POST: Almacenamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlmacenamiento,nombre,tipo,capacidad,costoProveedor,costoVenta,marca,rpm")] Almacenamiento almacenamiento)
        {
            almacenamiento.estatus = true;
            if (ModelState.IsValid)
            {
                db.Almacenamiento.Add(almacenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", almacenamiento.marca);
            ViewBag.tipo = new SelectList(db.TipoAlmacenamiento, "idTipoAlmacenamiento", "nombre", almacenamiento.tipo);
            return View(almacenamiento);
        }

        // GET: Almacenamiento/Edit/5
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
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", almacenamiento.marca);
            ViewBag.tipo = new SelectList(db.TipoAlmacenamiento, "idTipoAlmacenamiento", "nombre", almacenamiento.tipo);
            return View(almacenamiento);
        }

        // POST: Almacenamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlmacenamiento,nombre,tipo,capacidad,costoProveedor,costoVenta,estatus,marca,rpm")] Almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", almacenamiento.marca);
            ViewBag.tipo = new SelectList(db.TipoAlmacenamiento, "idTipoAlmacenamiento", "nombre", almacenamiento.tipo);
            return View(almacenamiento);
        }

        // GET: Almacenamiento/Delete/5
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

        // POST: Almacenamiento/Delete/5
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
