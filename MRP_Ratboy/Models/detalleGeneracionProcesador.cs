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
    
    public partial class detalleGeneracionProcesador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public detalleGeneracionProcesador()
        {
            this.GeneracionSoportadaPlacaMadre = new HashSet<GeneracionSoportadaPlacaMadre>();
            this.procesador = new HashSet<procesador>();
        }
    
        public int idGeneracionProcesador { get; set; }
        public string DetalleGeneracionProcesador1 { get; set; }
        public bool estatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneracionSoportadaPlacaMadre> GeneracionSoportadaPlacaMadre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<procesador> procesador { get; set; }
    }
}
