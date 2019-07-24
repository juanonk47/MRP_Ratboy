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
    public class tipoMemoriasController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: tipoMemorias
        public ActionResult Index()
        {
            return View(db.tipoMemoria.ToList());
        }

        // GET: tipoMemorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoMemoria tipoMemoria = db.tipoMemoria.Find(id);
            if (tipoMemoria == null)
            {
                return HttpNotFound();
            }
            return View(tipoMemoria);
        }

        // GET: tipoMemorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoMemorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoMemoria,tipo,estatus")] tipoMemoria tipoMemoria)
        {
            if (ModelState.IsValid)
            {
                db.tipoMemoria.Add(tipoMemoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoMemoria);
        }

        // GET: tipoMemorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoMemoria tipoMemoria = db.tipoMemoria.Find(id);
            if (tipoMemoria == null)
            {
                return HttpNotFound();
            }
            return View(tipoMemoria);
        }

        // POST: tipoMemorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoMemoria,tipo,estatus")] tipoMemoria tipoMemoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMemoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoMemoria);
        }

        // GET: tipoMemorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoMemoria tipoMemoria = db.tipoMemoria.Find(id);
            if (tipoMemoria == null)
            {
                return HttpNotFound();
            }
            return View(tipoMemoria);
        }

        // POST: tipoMemorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoMemoria tipoMemoria = db.tipoMemoria.Find(id);
            db.tipoMemoria.Remove(tipoMemoria);
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
