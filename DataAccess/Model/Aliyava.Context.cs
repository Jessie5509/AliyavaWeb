﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AliyavaEntities : DbContext
    {
        public AliyavaEntities()
            : base("name=AliyavaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Historico_de_Cambio_de_estados> Historico_de_Cambio_de_estados { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Reparto> Reparto { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<HistoricoStock> HistoricoStock { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
    }
}
