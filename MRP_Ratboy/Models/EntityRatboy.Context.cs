﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_ArmadoPcEntities : DbContext
    {
        public BD_ArmadoPcEntities()
            : base("name=BD_ArmadoPcEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Almacenamiento> Almacenamiento { get; set; }
        public virtual DbSet<detalleGeneracionProcesador> detalleGeneracionProcesador { get; set; }
        public virtual DbSet<Ensamble> Ensamble { get; set; }
        public virtual DbSet<LogEmpleado> LogEmpleado { get; set; }
        public virtual DbSet<modeloVideo> modeloVideo { get; set; }
        public virtual DbSet<PlacaMadre> PlacaMadre { get; set; }
        public virtual DbSet<procesador> procesador { get; set; }
        public virtual DbSet<socket> socket { get; set; }
        public virtual DbSet<Tamaño> Tamaño { get; set; }
        public virtual DbSet<tarjetaVideo> tarjetaVideo { get; set; }
        public virtual DbSet<tipo_usuarios> tipo_usuarios { get; set; }
        public virtual DbSet<tipoMemoria> tipoMemoria { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<cuelloBotella> cuelloBotella { get; set; }
        public virtual DbSet<memoriaRAM> memoriaRAM { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<URLImagenes> URLImagenes { get; set; }
    }
}
