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
    
    public partial class pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedido()
        {
            this.detalle_pedido = new HashSet<detalle_pedido>();
        }
    
        public int idPedido { get; set; }
        public int idProveedor { get; set; }
        public Nullable<int> idEmpleado { get; set; }
        public Nullable<System.DateTime> fechaHoraPedido { get; set; }
        public string codPedido { get; set; }
        public Nullable<decimal> subTotal { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<bool> estatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_pedido> detalle_pedido { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual proveedor proveedor { get; set; }
    }
}