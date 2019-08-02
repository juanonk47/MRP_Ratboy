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
    public class GabinetesController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Gabinetes
        public ActionResult Index()
        {
            var gabinete = db.Gabinete.Include(g => g.Marca1);
            return View(gabinete.ToList());
        }

        // GET: Gabinetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinete.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        // GET: Gabinetes/Create
        public ActionResult Create()
        {
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre");
            return View();
        }

        // POST: Gabinetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGabinete,costoProveedor,costoVenta,marca,modelo,medida")] Gabinete gabinete)
        {
            gabinete.estatus = true;
            if (ModelState.IsValid)
            {
                db.Gabinete.Add(gabinete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", gabinete.marca);
            return View(gabinete);
        }

        // GET: Gabinetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinete.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", gabinete.marca);
            return View(gabinete);
        }

        // POST: Gabinetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGabinete,costoProveedor,costoVenta,marca,modelo,medida,estatus")] Gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gabinete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", gabinete.marca);
            return View(gabinete);
        }

        // GET: Gabinetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinete.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        // POST: Gabinetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gabinete gabinete = db.Gabinete.Find(id);
            db.Gabinete.Remove(gabinete);
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
