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
    public class cuelloBotellasController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: cuelloBotellas
        public ActionResult Index()
        {
            var cuelloBotella = db.cuelloBotella.Include(c => c.Ensamble).Include(c => c.procesador).Include(c => c.tarjetaVideo);
            return View(cuelloBotella.ToList());
        }

        // GET: cuelloBotellas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuelloBotella cuelloBotella = db.cuelloBotella.Find(id);
            if (cuelloBotella == null)
            {
                return HttpNotFound();
            }
            return View(cuelloBotella);
        }

        // GET: cuelloBotellas/Create
        public ActionResult Create()
        {
            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble");
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre");
            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre");
            return View();
        }

        // POST: cuelloBotellas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCuelloBotella,idEnsamble_FK,estatus,idProcesador_FK,modelo,comnetarios,idTarjetaVideo_FK")] cuelloBotella cuelloBotella)
        {
            if (ModelState.IsValid)
            {
                db.cuelloBotella.Add(cuelloBotella);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble", cuelloBotella.idEnsamble_FK);
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre", cuelloBotella.idProcesador_FK);
            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre", cuelloBotella.idTarjetaVideo_FK);
            return View(cuelloBotella);
        }

        // GET: cuelloBotellas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuelloBotella cuelloBotella = db.cuelloBotella.Find(id);
            if (cuelloBotella == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble", cuelloBotella.idEnsamble_FK);
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre", cuelloBotella.idProcesador_FK);
            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre", cuelloBotella.idTarjetaVideo_FK);
            return View(cuelloBotella);
        }

        // POST: cuelloBotellas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCuelloBotella,idEnsamble_FK,estatus,idProcesador_FK,modelo,comnetarios,idTarjetaVideo_FK")] cuelloBotella cuelloBotella)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuelloBotella).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEnsamble_FK = new SelectList(db.Ensamble, "idEnsamble", "idEnsamble", cuelloBotella.idEnsamble_FK);
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre", cuelloBotella.idProcesador_FK);
            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre", cuelloBotella.idTarjetaVideo_FK);
            return View(cuelloBotella);
        }

        // GET: cuelloBotellas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuelloBotella cuelloBotella = db.cuelloBotella.Find(id);
            if (cuelloBotella == null)
            {
                return HttpNotFound();
            }
            return View(cuelloBotella);
        }

        // POST: cuelloBotellas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuelloBotella cuelloBotella = db.cuelloBotella.Find(id);
            db.cuelloBotella.Remove(cuelloBotella);
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
