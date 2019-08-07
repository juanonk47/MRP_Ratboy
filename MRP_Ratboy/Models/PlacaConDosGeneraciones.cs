using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Ratboy.Models
{
    public class PlacaConDosGeneraciones
    {
        public string Nombre { get; set; }
        public int idtipoMemoria { get; set; }
        public int maxVelocidadMemoria { get; set; }
        public bool statusM2 { get; set; }
        public int cantidadM2 { get; set; }
        public string Descripcion { get; set; }
        public bool Gaming { get; set; }
        public int idTamaño_FK { get; set; }
        public string codBarras { get; set; }
        public int PCIexpress { get; set; }
        public int SATA { get; set; }
        public bool estatus { get; set; }
        public double costoProveedor { get; set; }
        public double costoVenta { get; set; }
        public int marca { get; set; }
        public string modelo { get; set; }
        public int watts { get; set; }
        public int idSocket_FK { get; set; }

        public int detalleGeneracionProcesador { get; set; }
        public int detalleGeneracionProcesador2 { get; set; }


    }
}