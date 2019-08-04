using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.Controllers
{
    public class PedidoClienteController : Controller
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();
        //Recibe un id de cliente

        public ActionResult mostrarPedidosCliente (int id)
        {
            List<pedido_ensamble> pedido_Ensambles = this.db.pedido_ensamble.Where(x => x.usuario_id == id).ToList();
            return View(pedido_Ensambles);
        }
        public ActionResult mostrarPedidoPorSession()
        {
            Usuarios user = (Usuarios)Session["usuario"];
            List<pedido_ensamble> pedido_Ensambles = this.db.pedido_ensamble.Where(x => x.usuario_id == user.idUsuario).ToList();
            return View(pedido_Ensambles);

        }
    }
}