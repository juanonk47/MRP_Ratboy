using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Ratboy.Models
{
    public class EEnsambleConPiezasDisponibles
    {
        public List<procesador> procesadors { get; set; }
        public List<memoriaRAM> memoriaRAMs { get; set; }
        public List<Almacenamiento>almacenamientos { get; set; }
        public List<Gabinete> gabinetes { get; set; }
        public List<tarjetaVideo> tarjetaVideos { get; set; }
        public List<Disipadores> Disipadores { get; set; }
        public List<fuentePoder> fuentePoders { get; set; }

    }
}