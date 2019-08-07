using MRP_Ratboy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRP_Ratboy.Controllers
{
    public class PedidosController : Controller
    {
        public BD_ArmadoPcEntities db =new  BD_ArmadoPcEntities();
        public ActionResult mostrarListaPedidos()
        {
            List<pedido_ensamble> pedido_Ensambles = this.db.pedido_ensamble.Where(x => x.departamento < 5).ToList();
            return View(pedido_Ensambles);
        }

    }
}