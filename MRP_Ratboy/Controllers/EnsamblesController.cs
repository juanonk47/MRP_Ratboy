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
    public class EnsamblesController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Ensambles
        public ActionResult Index()
        {
            var ensamble = db.Ensamble.Include(e => e.Almacenamiento).Include(e => e.fuentePoder).Include(e => e.Gabinete).Include(e => e.LogEmpleado).Include(e => e.memoriaRAM).Include(e => e.modeloVideo).Include(e => e.procesador);
            return View(ensamble.ToList());
        }

        // GET: Ensambles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensamble ensamble = db.Ensamble.Find(id);
            if (ensamble == null)
            {
                return HttpNotFound();
            }
            return View(ensamble);
        }

        // GET: Ensambles/Create
        public ActionResult Create()
        {
            ViewBag.idAlmacenamiento_FK = new SelectList(db.Almacenamiento, "idAlmacenamento", "nombre");
            ViewBag.idFuentePoder_FK = new SelectList(db.fuentePoder, "idFuentePoder", "marca");
            ViewBag.idGabinete_FK = new SelectList(db.Gabinete, "idGabinete", "marca");
            ViewBag.idEmpleado_FK = new SelectList(db.LogEmpleado, "idEmpleado", "idEmpleado");
            ViewBag.idRAM_FK = new SelectList(db.memoriaRAM, "idRAM", "nombre");
            ViewBag.idTarjetaVideo_FK = new SelectList(db.modeloVideo, "idModeloVideo", "modelo");
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre");
            return View();
        }

        // POST: Ensambles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEnsamble,idPlacaMadre_FK,idProcesador_FK,idRAM_FK,idAlmacenamiento_FK,idFuentePoder_FK,idTarjetaVideo_FK,idGabinete_FK,estatus,idEmpleado_FK")] Ensamble ensamble)
        {
            if (ModelState.IsValid)
            {
                db.Ensamble.Add(ensamble);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAlmacenamiento_FK = new SelectList(db.Almacenamiento, "idAlmacenamento", "nombre", ensamble.idAlmacenamiento_FK);
            ViewBag.idFuentePoder_FK = new SelectList(db.fuentePoder, "idFuentePoder", "marca", ensamble.idFuentePoder_FK);
            ViewBag.idGabinete_FK = new SelectList(db.Gabinete, "idGabinete", "marca", ensamble.idGabinete_FK);
            ViewBag.idEmpleado_FK = new SelectList(db.LogEmpleado, "idEmpleado", "idEmpleado", ensamble.idEmpleado_FK);
            ViewBag.idRAM_FK = new SelectList(db.memoriaRAM, "idRAM", "nombre", ensamble.idRAM_FK);
            ViewBag.idTarjetaVideo_FK = new SelectList(db.modeloVideo, "idModeloVideo", "modelo", ensamble.idTarjetaVideo_FK);
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre", ensamble.idProcesador_FK);
            return View(ensamble);
        }

        // GET: Ensambles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensamble ensamble = db.Ensamble.Find(id);
            if (ensamble == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAlmacenamiento_FK = new SelectList(db.Almacenamiento, "idAlmacenamento", "nombre", ensamble.idAlmacenamiento_FK);
            ViewBag.idFuentePoder_FK = new SelectList(db.fuentePoder, "idFuentePoder", "marca", ensamble.idFuentePoder_FK);
            ViewBag.idGabinete_FK = new SelectList(db.Gabinete, "idGabinete", "marca", ensamble.idGabinete_FK);
            ViewBag.idEmpleado_FK = new SelectList(db.LogEmpleado, "idEmpleado", "idEmpleado", ensamble.idEmpleado_FK);
            ViewBag.idRAM_FK = new SelectList(db.memoriaRAM, "idRAM", "nombre", ensamble.idRAM_FK);
            ViewBag.idTarjetaVideo_FK = new SelectList(db.modeloVideo, "idModeloVideo", "modelo", ensamble.idTarjetaVideo_FK);
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre", ensamble.idProcesador_FK);
            return View(ensamble);
        }

        // POST: Ensambles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEnsamble,idPlacaMadre_FK,idProcesador_FK,idRAM_FK,idAlmacenamiento_FK,idFuentePoder_FK,idTarjetaVideo_FK,idGabinete_FK,estatus,idEmpleado_FK")] Ensamble ensamble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ensamble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlmacenamiento_FK = new SelectList(db.Almacenamiento, "idAlmacenamento", "nombre", ensamble.idAlmacenamiento_FK);
            ViewBag.idFuentePoder_FK = new SelectList(db.fuentePoder, "idFuentePoder", "marca", ensamble.idFuentePoder_FK);
            ViewBag.idGabinete_FK = new SelectList(db.Gabinete, "idGabinete", "marca", ensamble.idGabinete_FK);
            ViewBag.idEmpleado_FK = new SelectList(db.LogEmpleado, "idEmpleado", "idEmpleado", ensamble.idEmpleado_FK);
            ViewBag.idRAM_FK = new SelectList(db.memoriaRAM, "idRAM", "nombre", ensamble.idRAM_FK);
            ViewBag.idTarjetaVideo_FK = new SelectList(db.modeloVideo, "idModeloVideo", "modelo", ensamble.idTarjetaVideo_FK);
            ViewBag.idProcesador_FK = new SelectList(db.procesador, "idProcesador", "nombre", ensamble.idProcesador_FK);
            return View(ensamble);
        }

        // GET: Ensambles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensamble ensamble = db.Ensamble.Find(id);
            if (ensamble == null)
            {
                return HttpNotFound();
            }
            return View(ensamble);
        }

        // POST: Ensambles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ensamble ensamble = db.Ensamble.Find(id);
            db.Ensamble.Remove(ensamble);
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
