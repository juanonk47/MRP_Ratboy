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
    
    public partial class Gabinete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gabinete()
        {
            this.Ensamble = new HashSet<Ensamble>();
        }
    
        public int idGabinete { get; set; }
        public double costoProveedor { get; set; }
        public double costoVenta { get; set; }
        public int marca { get; set; }
        public string modelo { get; set; }
        public string medida { get; set; }
        public bool estatus { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ensamble> Ensamble { get; set; }
        public virtual Marca Marca1 { get; set; }
    }
}
