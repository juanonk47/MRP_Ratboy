using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Ratboy.Models
{
    public class PantallaDeProduccion
    {
        public int espera { get; set; }
        public int ensamblando { get; set; }
        public int instalando { get; set; }
        public int disponible { get; set; }
        public int fuera { get; set; }
    }
}