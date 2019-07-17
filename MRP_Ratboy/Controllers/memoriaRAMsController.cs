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
    public class memoriaRAMsController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: memoriaRAMs
        public ActionResult Index()
        {
            var memoriaRAM = db.memoriaRAM.Include(m => m.tipoMemoria);
            return View(memoriaRAM.ToList());
        }

        // GET: memoriaRAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memoriaRAM memoriaRAM = db.memoriaRAM.Find(id);
            if (memoriaRAM == null)
            {
                return HttpNotFound();
            }
            return View(memoriaRAM);
        }

        // GET: memoriaRAMs/Create
        public ActionResult Create()
        {
            ViewBag.idTipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo");
            return View();
        }

        // POST: memoriaRAMs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRAM,nombre,idTipoMemoria,cantidad,velocidad,estatus,costoVendedor,costoVenta,marca,watts")] memoriaRAM memoriaRAM)
        {
            if (ModelState.IsValid)
            {
                db.memoriaRAM.Add(memoriaRAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", memoriaRAM.idTipoMemoria);
            return View(memoriaRAM);
        }

        // GET: memoriaRAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memoriaRAM memoriaRAM = db.memoriaRAM.Find(id);
            if (memoriaRAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", memoriaRAM.idTipoMemoria);
            return View(memoriaRAM);
        }

        // POST: memoriaRAMs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRAM,nombre,idTipoMemoria,cantidad,velocidad,estatus,costoVendedor,costoVenta,marca,watts")] memoriaRAM memoriaRAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memoriaRAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", memoriaRAM.idTipoMemoria);
            return View(memoriaRAM);
        }

        // GET: memoriaRAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memoriaRAM memoriaRAM = db.memoriaRAM.Find(id);
            if (memoriaRAM == null)
            {
                return HttpNotFound();
            }
            return View(memoriaRAM);
        }

        // POST: memoriaRAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            memoriaRAM memoriaRAM = db.memoriaRAM.Find(id);
            db.memoriaRAM.Remove(memoriaRAM);
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
