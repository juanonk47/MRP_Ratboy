//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MRP_Ratboy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GeneracionSoportadaPlacaMadre
    {
        public int idGeneracionSoportadaPlacaMadre { get; set; }
        public int idPlacaMadre_FK { get; set; }
        public int idGeneracionProcesador_FK { get; set; }
        public bool estatus { get; set; }
    
        public virtual detalleGeneracionProcesador detalleGeneracionProcesador { get; set; }
        public virtual PlacaMadre PlacaMadre { get; set; }
    }
}