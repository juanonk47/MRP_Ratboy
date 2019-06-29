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
    
    public partial class PlacaMadre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlacaMadre()
        {
            this.detalleGeneracionProcesador = new HashSet<detalleGeneracionProcesador>();
            this.Ensamble = new HashSet<Ensamble>();
        }
    
        public int idPlacaMadre { get; set; }
        public string Nombre { get; set; }
        public int idtipoMemoria { get; set; }
        public int maxVelocidadMemoria { get; set; }
        public int statusM2 { get; set; }
        public int cantidadM2 { get; set; }
        public string Descripcion { get; set; }
        public int Gaming { get; set; }
        public int idTamaño { get; set; }
        public byte[] codBarras { get; set; }
        public int PCIexpress { get; set; }
        public int SATA { get; set; }
        public bool estatus { get; set; }
        public int idEnsamble { get; set; }
        public double costoProveedor { get; set; }
        public double costoVenta { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public Nullable<double> watts { get; set; }
        public int idSocket { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleGeneracionProcesador> detalleGeneracionProcesador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ensamble> Ensamble { get; set; }
        public virtual Ensamble Ensamble1 { get; set; }
        public virtual socket socket { get; set; }
        public virtual Tamaño Tamaño { get; set; }
        public virtual tipoMemoria tipoMemoria { get; set; }
    }
}
