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
        public ActionResult piezasSoportadas(int id)
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
                //VIEWBAG PARA PODER PONER EL COMBOBOX
                ViewBag.procesadoresDisponibles = new SelectList(procesadorFiltrados, "idProcesador", "nombre");


                //Filtrado de memorias ram
                var memorias = this.entities.tipoMemoria.Where(x => x.idTipoMemoria == placaMadre.idtipoMemoria);
                List<tipoMemoria> tiposdememoria = memorias.ToList();
                List<memoriaRAM> allMemoriasRam = this.entities.memoriaRAM.ToList();
                List<memoriaRAM> memoriasRamFiltradas = new List<memoriaRAM>();
                foreach (tipoMemoria tipo in tiposdememoria)
                {
                    foreach (memoriaRAM item in allMemoriasRam)
                    {
                        if (tipo.idTipoMemoria == item.idTipoMemoria && item.velocidad <= placaMadre.maxVelocidadMemoria)
                        {
                            memoriasRamFiltradas.Add(item);
                        }
                    }
                }
                //COMBO BOX DE LAS MEMORIAS RAM DISPONIBLES
                ViewBag.memoriasRamDisponibles = new SelectList(memoriasRamFiltradas, "idRAM","nombre");
                Ensamble e = new Ensamble();
                

                var almacenamiento = this.entities.Almacenamiento.ToList();
                Almacenamiento a = new Almacenamiento();
                ViewBag.almacenamientoDisponible = new SelectList(almacenamiento, "idAlmacenamiento", "nombre");
                ViewBag.GabinetesDisponibles = new SelectList(this.entities.Gabinete.ToList(), "idGabinete", "modelo");
                ViewBag.TarjetaDeVideoDisponible = new SelectList(this.entities.tarjetaVideo.ToList(), "idTarjetaVideo", "nombre");
                return View();
                
            }
            else
            {
                ViewBag.ErroPlacaMadre = "NO SE ENCONTRO LA PLACA MADRE";
                return View(placaMadre);
            }
            return View();
        }
        public ActionResult IndexPlacaMadre()
        {
            List<PlacaMadre> p = this.entities.PlacaMadre.ToList();
            return View(p);
        }
    }
}