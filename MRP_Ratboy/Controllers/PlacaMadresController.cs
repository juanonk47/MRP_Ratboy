using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
            ViewBag.detalleGeneracionProcesador = new SelectList(this.db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1");
            ViewBag.detalleGeneracionProcesador2 = new SelectList(this.db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1");
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre");
            ViewBag.idTamaño_FK = new SelectList(db.Tamaño, "idTamaño", "nombreTamaño");
            ViewBag.idtipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo");
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre");
            return View();
        }

        // POST: PlacaMadres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlacaMadre,Nombre,idtipoMemoria,maxVelocidadMemoria,statusM2,cantidadM2,Descripcion,Gaming,idTamaño_FK,codBarras,PCIexpress,SATA,costoProveedor,costoVenta,marca,modelo,watts,idSocket_FK,detalleGeneracionProcesador,detalleGeneracionProcesador2")] PlacaConDosGeneraciones placaMadre)
        {
            
                PlacaMadre placa = new PlacaMadre();
                placa.cantidad = 0;
                placa.cantidadM2 = placaMadre.cantidadM2;
                placa.codBarra = placaMadre.codBarras;
                placa.costoProveedor = placaMadre.costoProveedor;
                placa.costoVenta = placaMadre.costoVenta;
                placa.Descripcion = placaMadre.Descripcion;
                placa.estatus = true;
                placa.Gaming = placaMadre.Gaming;
                placa.idSocket_FK = placaMadre.idSocket_FK;
                placa.idTamaño_FK = placaMadre.idTamaño_FK;
                placa.idtipoMemoria = placaMadre.idtipoMemoria;
                placa.marca = placaMadre.marca;
                placa.maxVelocidadMemoria = placaMadre.maxVelocidadMemoria;
                placa.modelo = placaMadre.modelo;
                placa.Nombre = placaMadre.Nombre;
                placa.PCIexpress = placaMadre.PCIexpress;
                placa.SATA = placaMadre.SATA;
                placa.statusM2 = placaMadre.statusM2;
                placa.watts = placaMadre.watts;
                db.PlacaMadre.Add(placa);
                db.SaveChanges();
                GeneracionSoportadaPlacaMadre generacionSoportadaPlacaMadre = new GeneracionSoportadaPlacaMadre();
                generacionSoportadaPlacaMadre.idGeneracionProcesador_FK = placaMadre.detalleGeneracionProcesador;
                generacionSoportadaPlacaMadre.idPlacaMadre_FK = placa.idPlacaMadre;
                db.GeneracionSoportadaPlacaMadre.Add(generacionSoportadaPlacaMadre);
                db.SaveChanges();
                GeneracionSoportadaPlacaMadre generacionSoportadaPlacaMadre2 = new GeneracionSoportadaPlacaMadre();
                generacionSoportadaPlacaMadre.idGeneracionProcesador_FK = placaMadre.detalleGeneracionProcesador2;
                generacionSoportadaPlacaMadre.idPlacaMadre_FK = placa.idPlacaMadre;
                db.GeneracionSoportadaPlacaMadre.Add(generacionSoportadaPlacaMadre);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            ViewBag.detalleGeneracionProcesador = new SelectList(this.db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1");
            ViewBag.detalleGeneracionProcesador2 = new SelectList(this.db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1");
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre", placaMadre.idSocket_FK);
            ViewBag.idTamaño_FK = new SelectList(db.Tamaño, "idTamaño", "nombreTamaño", placaMadre.idTamaño_FK);
            ViewBag.idtipoMemoria = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", placaMadre.idtipoMemoria);
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", placaMadre.marca);
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
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", placaMadre.marca);
            return View(placaMadre);
        }

        // POST: PlacaMadres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlacaMadre,Nombre,idtipoMemoria,maxVelocidadMemoria,statusM2,cantidadM2,Descripcion,Gaming,idTamaño_FK,codBarras,PCIexpress,SATA,estatus,costoProveedor,costoVenta,marca,modelo,watts,idSocket_FK")] PlacaMadre placaMadre)
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
            ViewBag.marca = new SelectList(db.Marca, "idMarca", "nombre", placaMadre.marca);
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
        [HttpGet]
        public ActionResult SeleccionarGeneracion(int id)
        {
            PlacaMadre placaMadre = this.db.PlacaMadre.Find(id);
            List<detalleGeneracionProcesador> detalleGeneracionProcesador = this.db.detalleGeneracionProcesador.ToList();
            detalleGeneracionProcesador d = new detalleGeneracionProcesador();
            
            return View();
        }
       


    }
}
