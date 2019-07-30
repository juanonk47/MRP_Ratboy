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
    public class modeloVideosController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: modeloVideos
        public ActionResult Index()
        {
            var modeloVideo = db.modeloVideo.Include(m => m.tarjetaVideo);
            return View(modeloVideo.ToList());
        }

        // GET: modeloVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modeloVideo modeloVideo = db.modeloVideo.Find(id);
            if (modeloVideo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVideo);
        }

        // GET: modeloVideos/Create
        public ActionResult Create()
        {
            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre");
            return View();
        }

        // POST: modeloVideos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idModeloVideo,idTarjetaVideo_FK,modelo,estatus")] modeloVideo modeloVideo)
        {
            if (ModelState.IsValid)
            {
                db.modeloVideo.Add(modeloVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre", modeloVideo.idTarjetaVideo_FK);
            return View(modeloVideo);
        }

        // GET: modeloVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modeloVideo modeloVideo = db.modeloVideo.Find(id);
            if (modeloVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre", modeloVideo.idTarjetaVideo_FK);
            return View(modeloVideo);
        }

        // POST: modeloVideos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idModeloVideo,idTarjetaVideo_FK,modelo,estatus")] modeloVideo modeloVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modeloVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTarjetaVideo_FK = new SelectList(db.tarjetaVideo, "idTarjetaVideo", "nombre", modeloVideo.idTarjetaVideo_FK);
            return View(modeloVideo);
        }

        // GET: modeloVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modeloVideo modeloVideo = db.modeloVideo.Find(id);
            if (modeloVideo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVideo);
        }

        // POST: modeloVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modeloVideo modeloVideo = db.modeloVideo.Find(id);
            db.modeloVideo.Remove(modeloVideo);
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
