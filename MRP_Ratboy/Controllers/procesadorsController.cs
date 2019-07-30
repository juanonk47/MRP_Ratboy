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
    public class procesadorsController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: procesadors
        public ActionResult Index()
        {
            var procesador = db.procesador.Include(p => p.detalleGeneracionProcesador).Include(p => p.socket).Include(p => p.tipoMemoria);
            return View(procesador.ToList());
        }

        // GET: procesadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesador procesador = db.procesador.Find(id);
            if (procesador == null)
            {
                return HttpNotFound();
            }
            return View(procesador);
        }

        // GET: procesadors/Create
        public ActionResult Create()
        {
            ViewBag.idGeneracionProcesador_FK = new SelectList(db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1");
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre");
            ViewBag.idTipoMemoria_FK = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo");
            return View();
        }

        // POST: procesadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProcesador,nombre,cantidadNucleos,cantidadSubProcesos,frecuenciaBasica,idTipoMemoria_FK,idSocket_FK,graficosIntegrados,optane,costoProveedor,costoVenta,marca,estatus,watts,idGeneracionProcesador_FK")] procesador procesador)
        {
            if (!(ValidarNombre(procesador.nombre)))
            {
                if (ModelState.IsValid)
                {
                    db.procesador.Add(procesador);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "El nombre del procesador ya ha sido registrado, utilice otro nombre";
                
            }


            ViewBag.idGeneracionProcesador_FK = new SelectList(db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1", procesador.idGeneracionProcesador_FK);
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre", procesador.idSocket_FK);
            ViewBag.idTipoMemoria_FK = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", procesador.idTipoMemoria_FK);
            return View(procesador);
        }

        // GET: procesadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesador procesador = db.procesador.Find(id);
            if (procesador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGeneracionProcesador_FK = new SelectList(db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1", procesador.idGeneracionProcesador_FK);
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre", procesador.idSocket_FK);
            ViewBag.idTipoMemoria_FK = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", procesador.idTipoMemoria_FK);
            return View(procesador);
        }

        // POST: procesadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProcesador,nombre,cantidadNucleos,cantidadSubProcesos,frecuenciaBasica,idTipoMemoria_FK,idSocket_FK,graficosIntegrados,optane,costoProveedor,costoVenta,marca,estatus,watts,idGeneracionProcesador_FK")] procesador procesador)
        {
            if (!(ValidarNombre(procesador.nombre)))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(procesador).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "El nombre del procesador ya ha sido registrado, utilice otro nombre";

            }
            ViewBag.idGeneracionProcesador_FK = new SelectList(db.detalleGeneracionProcesador, "idGeneracionProcesador", "DetalleGeneracionProcesador1", procesador.idGeneracionProcesador_FK);
            ViewBag.idSocket_FK = new SelectList(db.socket, "idSocket", "nombre", procesador.idSocket_FK);
            ViewBag.idTipoMemoria_FK = new SelectList(db.tipoMemoria, "idTipoMemoria", "tipo", procesador.idTipoMemoria_FK);
            return View(procesador);
        }

        // GET: procesadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesador procesador = db.procesador.Find(id);
            if (procesador == null)
            {
                return HttpNotFound();
            }
            return View(procesador);
        }

        // POST: procesadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            procesador procesador = db.procesador.Find(id);
            db.procesador.Remove(procesador);
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
        

        private bool ValidarNombre(string nombre)
        {
            return db.procesador.Any(x => x.nombre.Equals(nombre)); //Reducir el ámbito del contexto
        }
    }
}
