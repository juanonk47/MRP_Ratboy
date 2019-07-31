﻿using System;
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
    public class UsuariosController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var session = Session["usuario"];
            if (session == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var usuarios = db.Usuarios.Include(u => u.tipo_usuarios);
            return View(usuarios.ToList());
        }
        public ActionResult session_detalle() {
            Usuarios usuario = (Usuarios)Session["usuario"];
            if (usuario != null) {
                return View(usuario);
            }
            return View();
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.tipo_id = new SelectList(db.tipo_usuarios, "id", "descripcion");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,tipo_id,estatus")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipo_id = new SelectList(db.tipo_usuarios, "id", "descripcion", usuarios.tipo_id_FK);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo_id = new SelectList(db.tipo_usuarios, "id", "descripcion", usuarios.tipo_id_FK);
            if (usuarios.estatus == 1)
            {
                ViewBag.checkestatus = true;
            }
            if (usuarios.estatus == 0)
            {
                ViewBag.checkestatus = false;
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,username,password,tipo_id,estatus,checkestatus,persona")] Usuarios usuarios)
        {
            if (ViewBag.checkestatus)
            {
                usuarios.estatus = 1;
            }
            else
            {
                usuarios.estatus = 0;
            }
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipo_id = new SelectList(db.tipo_usuarios, "id", "descripcion", usuarios.tipo_id_FK);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost,ActionName("temporal")]
        public ActionResult DeleteTemporal(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            usuarios.estatus = 0;
            db.Entry(usuarios).State = EntityState.Modified;
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
        public ActionResult BuscarPorCorreo(string correo)
        {
            var usuarios = db.Usuarios.Where(x => x.username.Contains(correo));
            return View(usuarios.ToList());
        }
        [HttpGet]
        public ActionResult mostrarPorEstatus(int estatus)
        {
            var usuarios = db.Usuarios.Where(x => x.estatus == estatus);
            return View("Index",usuarios.ToList());
        }

    }
}
