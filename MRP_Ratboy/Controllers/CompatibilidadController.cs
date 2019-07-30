using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.Controllers
{
    public class CompatibilidadController : Controller
    {
        // GET: Compatibilidad
        public BD_ArmadoPcEntities entities = new BD_ArmadoPcEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //RECIBO EL ID DE UNA PLACA MADRE PARA PODER FILTRAR LOS PROCESADORES DISPONIBLES
        public ActionResult procesadorSoportados(int id)
        {
            PlacaMadre placaMadre = this.entities.PlacaMadre.Find(id);
            
            if (placaMadre != null)
            {
                var generacionSoportada = this.entities.GeneracionSoportadaPlacaMadre.Where(x => x.idPlacaMadre_FK == placaMadre.idPlacaMadre);
                List<GeneracionSoportadaPlacaMadre> generacionSoportadaList = generacionSoportada.ToList();
                List<procesador> procesadorFiltrados = new List<procesador>();
                
                foreach (GeneracionSoportadaPlacaMadre generacionSoportadaPlacaMadre in generacionSoportadaList)
                {
                    var procesadores = this.entities.procesador.Where(p => p.idGeneracionProcesador_FK == generacionSoportadaPlacaMadre.idGeneracionProcesador_FK);
                    procesadorFiltrados.AddRange(procesadores.ToList());
                }
                ViewBag.procesadoresDisponibles = procesadorFiltrados;
                return View();
                
            }
            else
            {
                ViewBag.ErroPlacaMadre = "NO SE ENCONTRO LA PLACA MADRE";
                return View(placaMadre);
            }
            return View();
        }
    }
}