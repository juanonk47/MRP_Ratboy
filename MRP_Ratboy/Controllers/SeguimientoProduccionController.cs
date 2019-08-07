using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.Controllers
{
    public class SeguimientoProduccionController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();
        public ActionResult Index()
        {
            PantallaDeProduccion pantalla = new PantallaDeProduccion();
            List<pedido_ensamble> pedido_Ensambles = this.db.pedido_ensamble.ToList();
            foreach (pedido_ensamble item in pedido_Ensambles)
            {
                switch (item.departamento)
                {
                    case 1:
                        pantalla.espera++;
                        break;
                    case 2:
                        pantalla.ensamblando++;
                        break;
                    case 3:
                        pantalla.instalando++;
                        break;
                    case 4:
                        pantalla.disponible++;
                        break;
                    case 5:
                        pantalla.fuera++;
                        break;
                }
            }
            return View(pantalla);
        }
        [HttpPost]
        public ActionResult Avance([Bind(Include = "pedido_id")] pedido_ensamble p)
        {
            pedido_ensamble pedido = this.db.pedido_ensamble.Find(p.pedido_id);
            pedido.departamento++;
            this.db.Entry(pedido).State = EntityState.Modified;
            db.SaveChanges();
            if (pedido.departamento == 5)
            {
                //MANDAR CORREL ELECTRONICO AL CLIENTE
            }
            ViewBag.Movimiento = "Pedido Movido de departamento";
            return RedirectToAction("Index");
        }
        public ActionResult Avance()
        {
            return View();
        }
    }
}