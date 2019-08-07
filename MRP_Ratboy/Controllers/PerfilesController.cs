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
    public class PerfilesController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Perfiles
        public ActionResult Index()
        {
            return View(db.Perfiles.ToList());
        }

        // GET: Perfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // GET: Perfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPerfil,Nombre,Nivel")] Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                perfiles.estatus = true;
                db.Perfiles.Add(perfiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfiles);
        }

        // GET: Perfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: Perfiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPerfil,Nombre,Nivel,idEnsamble_FK,estatus")] Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfiles);
        }

        // GET: Perfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: Perfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfiles perfiles = db.Perfiles.Find(id);
            db.Perfiles.Remove(perfiles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult mostrarPerfilesConEnsambles()
        {
            List<EPerfilesConEnsambles> ePerfilesConEnsambles = new List<EPerfilesConEnsambles>();
            List<Perfil_Ensamble> perfil_Ensambles = this.db.Perfil_Ensamble.Include(x => x.Ensamble).Include(x => x.Perfiles).ToList();
            foreach(Perfil_Ensamble item in perfil_Ensambles)
            {
                EPerfilesConEnsambles ePerfilesConEnsamble = new EPerfilesConEnsambles();
                ePerfilesConEnsamble.ensambles = new List<Ensamble>();
                PlacaMadre placaEnsamble = this.db.PlacaMadre.Find(item.Ensamble.idPlacaMadre_FK);
                if (placaEnsamble.cantidad <= 0)
                {
                    break;
                }
                procesador procesadorEnsamble = this.db.procesador.Find(item.Ensamble.idProcesador_FK);
                if (procesadorEnsamble.cantidad <= 0)
                {
                    break;
                }
                fuentePoder fuentePoder = this.db.fuentePoder.Find(item.Ensamble.idFuentePoder_FK);
                if (fuentePoder.cantidad <= 0)
                {
                    break;
                }
                Gabinete gabineteEnsamble = this.db.Gabinete.Find(item.Ensamble.idGabinete_FK);
                if (gabineteEnsamble.cantidad <= 0)
                {
                    break;
                }
                tarjetaVideo tarjetaVideoEnsamble = this.db.tarjetaVideo.Find(item.Ensamble.idTarjetaVideo_FK);
                if (tarjetaVideoEnsamble.cantidad <= 0)
                {
                    break;
                }
                List<memoriaRAM_Ensamble> memoriaRAM_Ensambles = this.db.memoriaRAM_Ensamble.Include(x=>x.memoriaRAM).Where(X => X.idEnsamble_FK == item.Ensamble.idEnsamble).ToList();
                bool existenciasme = true;
                foreach(memoriaRAM_Ensamble memoria in memoriaRAM_Ensambles)
                {
                    if (memoria.memoriaRAM.cantidad <= 0)
                    {
                        existenciasme = false;
                    }
                }
                if (!existenciasme)
                {
                    break;
                }
                List<Almacenamiento_Ensamble> almacenamiento_Ensambles = this.db.Almacenamiento_Ensamble.Include(x => x.Almacenamiento).Where(x => x.idEnsamble_FK == item.idEnsamble_FK).ToList();
                bool existenciaALM = true;
                foreach(Almacenamiento_Ensamble almacenamiento in almacenamiento_Ensambles)
                {
                    if (almacenamiento.Almacenamiento.cantidad <= 0)
                    {
                        existenciaALM = false;
                    }
                }
                if (!existenciaALM)
                {
                    break;
                }
                Ensamble ensamble = new Ensamble();
                ensamble.procesador = procesadorEnsamble;
                ensamble.PlacaMadre = placaEnsamble;
                ensamble.Gabinete = gabineteEnsamble;
                ensamble.fuentePoder = fuentePoder;
                if (item.Ensamble.Disipadores.cantidad <= 0)
                {
                    break;
                }
                ensamble.Disipadores = item.Ensamble.Disipadores;
                ePerfilesConEnsamble.ensambles.Add(ensamble);
                ePerfilesConEnsamble.Perfiles = item.Perfiles;
                int posicion = checarPerfilExiste(ePerfilesConEnsambles, ePerfilesConEnsamble);
                if ( posicion>= 0)
                {
                    ePerfilesConEnsambles.ElementAt(posicion).ensambles.Add(ensamble);
                }
                else
                {
                    ePerfilesConEnsambles.Add(ePerfilesConEnsamble);
                }
                
            }
            return Json(ePerfilesConEnsambles);

        }
        public int checarPerfilExiste(List<EPerfilesConEnsambles> ePerfilesConEnsambles, EPerfilesConEnsambles ePerfilesCon)
        {
            int i = 0;
            foreach (EPerfilesConEnsambles item in ePerfilesConEnsambles)
            {
                if (item.Perfiles.idPerfil == ePerfilesCon.Perfiles.idPerfil)
                {
                    return i;
                }
                i++;
            }
            return -1;
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
