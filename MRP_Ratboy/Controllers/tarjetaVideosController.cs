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
    public class tarjetaVideosController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: tarjetaVideos
        public ActionResult Index()
        {
            return View(db.tarjetaVideo.ToList());
        }
         
        // GET: tarjetaVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjetaVideo tarjetaVideo = db.tarjetaVideo.Find(id);
            if (tarjetaVideo == null)
            {
                return HttpNotFound();
            }
            return View(tarjetaVideo);
        }

        // GET: tarjetaVideos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tarjetaVideos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTarjetaVideo,nombre,arquitectura,cudaCore,frameBuffer,velocidadReloj,velocidadMemoria,nombreModelo,estatus")] tarjetaVideo tarjetaVideo)
        {
            if (ModelState.IsValid)
            {
                db.tarjetaVideo.Add(tarjetaVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarjetaVideo);
        }

        // GET: tarjetaVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjetaVideo tarjetaVideo = db.tarjetaVideo.Find(id);
            if (tarjetaVideo == null)
            {
                return HttpNotFound();
            }
            return View(tarjetaVideo);
        }

        // POST: tarjetaVideos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTarjetaVideo,nombre,arquitectura,cudaCore,frameBuffer,velocidadReloj,velocidadMemoria,nombreModelo,estatus")] tarjetaVideo tarjetaVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjetaVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarjetaVideo);
        }

        // GET: tarjetaVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjetaVideo tarjetaVideo = db.tarjetaVideo.Find(id);
            if (tarjetaVideo == null)
            {
                return HttpNotFound();
            }
            return View(tarjetaVideo);
        }

        // POST: tarjetaVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tarjetaVideo tarjetaVideo = db.tarjetaVideo.Find(id);
            db.tarjetaVideo.Remove(tarjetaVideo);
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
