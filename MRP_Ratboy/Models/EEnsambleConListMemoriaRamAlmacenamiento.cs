using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Ratboy.Models
{
    public class EEnsambleConListMemoriaRamAlmacenamiento
    {
        public Ensamble ensamble { get; set; }
        public List<memoriaRAM> memoriaRAMs { get; set; }
        public List<Almacenamiento> almacenamientos { get; set; }

    }
}