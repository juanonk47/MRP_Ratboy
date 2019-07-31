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
    public class fuentePodersController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: fuentePoders
        public ActionResult Index()
        {
            return View(db.fuentePoder.ToList());
        }

        // GET: fuentePoders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuentePoder fuentePoder = db.fuentePoder.Find(id);
            if (fuentePoder == null)
            {
                return HttpNotFound();
            }
            return View(fuentePoder);
        }

        // GET: fuentePoders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fuentePoders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFuentePoder,costoProveedor,costoVenta,marca,modelo,estatus,watts,tamaño,certificado")] fuentePoder fuentePoder)
        {
            if (ModelState.IsValid)
            {
                db.fuentePoder.Add(fuentePoder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuentePoder);
        }

        // GET: fuentePoders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuentePoder fuentePoder = db.fuentePoder.Find(id);
            if (fuentePoder == null)
            {
                return HttpNotFound();
            }
            return View(fuentePoder);
        }

        // POST: fuentePoders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFuentePoder,costoProveedor,costoVenta,marca,modelo,estatus,watts,tamaño,certificado")] fuentePoder fuentePoder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuentePoder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuentePoder);
        }

        // GET: fuentePoders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuentePoder fuentePoder = db.fuentePoder.Find(id);
            if (fuentePoder == null)
            {
                return HttpNotFound();
            }
            return View(fuentePoder);
        }

        // POST: fuentePoders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fuentePoder fuentePoder = db.fuentePoder.Find(id);
            db.fuentePoder.Remove(fuentePoder);
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
