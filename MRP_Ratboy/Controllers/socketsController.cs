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
    public class socketsController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: sockets
        public ActionResult Index()
        {
            return View(db.socket.ToList());
        }

        // GET: sockets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socket socket = db.socket.Find(id);
            if (socket == null)
            {
                return HttpNotFound();
            }
            return View(socket);
        }

        // GET: sockets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sockets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSocket,nombre,estatus")] socket socket)
        {
            if (ModelState.IsValid)
            {
                db.socket.Add(socket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socket);
        }

        // GET: sockets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socket socket = db.socket.Find(id);
            if (socket == null)
            {
                return HttpNotFound();
            }
            return View(socket);
        }

        // POST: sockets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSocket,nombre,estatus")] socket socket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socket);
        }

        // GET: sockets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socket socket = db.socket.Find(id);
            if (socket == null)
            {
                return HttpNotFound();
            }
            return View(socket);
        }

        // POST: sockets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            socket socket = db.socket.Find(id);
            db.socket.Remove(socket);
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
