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
    public class PlacaMadresController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: PlacaMadres
        public ActionResult Index()
        {
            var placaMadre = db.PlacaMadre.Include(p => p.socket).Include(p => p.Tamaño).Include(p => p.tipoMemoria);
            return View(placaMadre.ToList());
        }

        // GET: PlacaMadres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMadre placaMadre = db.PlacaMadre.Find(id);
            if (placaMadre == null)
            {
                return HttpNotFound();
            }
            return View(placaMadre);
        }

        // GET: PlacaMadres/Create
        public ActionResult Create()
        {
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre");
            ViewBag.idTamaño_FK = new SelectList(db.Tamaño, "idTamaño", "nombreTamaño");
            ViewBag.idtipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo");
            return View();
        }

        // POST: PlacaMadres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlacaMadre,Nombre,idtipoMemoria,maxVelocidadMemoria,statusM2,cantidadM2,Descripcion,Gaming,idTamaño_FK,codBarras,PCIexpress,SATA,estatus,idEnsamble,costoProveedor,costoVenta,marca,modelo,watts,idSocket_FK")] PlacaMadre placaMadre)
        {
            if (ModelState.IsValid)
            {
                db.PlacaMadre.Add(placaMadre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre", placaMadre.idSocket_FK);
            ViewBag.idTamaño_FK = new SelectList(db.Tamaño, "idTamaño", "nombreTamaño", placaMadre.idTamaño_FK);
            ViewBag.idtipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", placaMadre.idtipoMemoria);
            return View(placaMadre);
        }

        // GET: PlacaMadres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMadre placaMadre = db.PlacaMadre.Find(id);
            if (placaMadre == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre", placaMadre.idSocket_FK);
            ViewBag.idTamaño_FK = new SelectList(db.Tamaño, "idTamaño", "nombreTamaño", placaMadre.idTamaño_FK);
            ViewBag.idtipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", placaMadre.idtipoMemoria);
            return View(placaMadre);
        }

        // POST: PlacaMadres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlacaMadre,Nombre,idtipoMemoria,maxVelocidadMemoria,statusM2,cantidadM2,Descripcion,Gaming,idTamaño_FK,codBarras,PCIexpress,SATA,estatus,idEnsamble,costoProveedor,costoVenta,marca,modelo,watts,idSocket_FK")] PlacaMadre placaMadre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placaMadre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre", placaMadre.idSocket_FK);
            ViewBag.idTamaño_FK = new SelectList(db.Tamaño, "idTamaño", "nombreTamaño", placaMadre.idTamaño_FK);
            ViewBag.idtipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", placaMadre.idtipoMemoria);
            return View(placaMadre);
        }

        // GET: PlacaMadres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMadre placaMadre = db.PlacaMadre.Find(id);
            if (placaMadre == null)
            {
                return HttpNotFound();
            }
            return View(placaMadre);
        }

        // POST: PlacaMadres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlacaMadre placaMadre = db.PlacaMadre.Find(id);
            db.PlacaMadre.Remove(placaMadre);
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
