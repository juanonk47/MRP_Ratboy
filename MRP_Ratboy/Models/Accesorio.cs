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
    
    public partial class Accesorio
    {
        public int idAccesorio { get; set; }
        public int categoria { get; set; }
        public string nombre { get; set; }
        public int marca { get; set; }
        public string modelo { get; set; }
        public decimal precioProveedor { get; set; }
        public decimal precioVenta { get; set; }
        public bool estatus { get; set; }
        public string descripcion { get; set; }
    
        public virtual Marca Marca1 { get; set; }
    }
}