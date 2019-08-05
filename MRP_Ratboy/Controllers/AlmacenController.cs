using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.Controllers
{
    public class AlmacenController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();
        public ActionResult Almacen()
        {
            ListaDeProductosAlmacen listaDeProductosAlmacen = new ListaDeProductosAlmacen();
            listaDeProductosAlmacen.almacenamientos = this.db.Almacenamiento.ToList();
            listaDeProductosAlmacen.fuentePoders = this.db.fuentePoder.ToList();
            listaDeProductosAlmacen.gabinetes = this.db.Gabinete.ToList();
            listaDeProductosAlmacen.memoriaRAMs = this.db.memoriaRAM.ToList();
            listaDeProductosAlmacen.placaMadres = this.db.PlacaMadre.ToList();
            listaDeProductosAlmacen.procesadors = this.db.procesador.ToList();
            listaDeProductosAlmacen.tarjetaVideos = this.db.tarjetaVideo.ToList();
            return View(listaDeProductosAlmacen);
        }
        public ActionResult AjusteAlmacenamiento(int? id,int? cantidad)
        {
            Almacenamiento almacenamiento = this.db.Almacenamiento.Find(id);
            almacenamiento.cantidad += cantidad;
            db.Entry(almacenamiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjusteFuenteDePoder(int? id, int? cantidad)
        {
            fuentePoder almacenamiento = this.db.fuentePoder.Find(id);
            almacenamiento.cantidad += cantidad;
            db.Entry(almacenamiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjusteGabiente(int? id, int? cantidad)
        {
            Gabinete almacenamiento = this.db.Gabinete.Find(id);
            almacenamiento.cantidad += cantidad;
            db.Entry(almacenamiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjusteMemoriasRam(int? id, int cantidad)
        {
            memoriaRAM almacenamiento = db.memoriaRAM.Find(id);
            almacenamiento.cantidad += cantidad;
            db.Entry(almacenamiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjustePlacaMadre(int? id, int? cantidad)
        {
            PlacaMadre almacenamiento = this.db.PlacaMadre.Find(id);
            almacenamiento.cantidad += cantidad;
            db.Entry(almacenamiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjusteProcesador(int? id, int? cantidad)
        {
            procesador almacenamiento = this.db.procesador.Find(id);
            almacenamiento.cantidad += cantidad;
            db.Entry(almacenamiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjusteTarjetaDeVideo(int? id, int? cantidad)
        {
            fuentePoder almacenamiento = this.db.fuentePoder.Find(id);
            almacenamiento.cantidad += cantidad;
            db.Entry(almacenamiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}