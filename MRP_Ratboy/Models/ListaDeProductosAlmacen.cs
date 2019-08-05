using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Ratboy.Models
{
    public class ListaDeProductosAlmacen
    {
        public List<PlacaMadre> placaMadres { get; set; }
        public List<memoriaRAM> memoriaRAMs { get; set; }
        public List<procesador> procesadors { get; set; }
        public List<fuentePoder> fuentePoders { get; set; }
        public List<tarjetaVideo> tarjetaVideos { get; set; }
        public List<Almacenamiento> almacenamientos { get; set; }
        public List<Gabinete> gabinetes { get; set; }
    }
}