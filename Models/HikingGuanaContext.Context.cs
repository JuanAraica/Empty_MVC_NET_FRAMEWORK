﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plantilla.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A6C1FF_HikingGuanacasteEntities : DbContext
    {
        public DB_A6C1FF_HikingGuanacasteEntities()
            : base("name=DB_A6C1FF_HikingGuanacasteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Atraccion> Atraccion { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Cupon> Cupon { get; set; }
        public virtual DbSet<Destino> Destino { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<GestionAdmin> GestionAdmin { get; set; }
        public virtual DbSet<Referencia> Referencia { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<TablaActividades> TablaActividades { get; set; }
        public virtual DbSet<TablaAtracciones> TablaAtracciones { get; set; }
        public virtual DbSet<TablaColaboradores> TablaColaboradores { get; set; }
        public virtual DbSet<TablaDestinos> TablaDestinos { get; set; }
        public virtual DbSet<TablaToures> TablaToures { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<Transporte> Transporte { get; set; }
        public virtual DbSet<Colaborador> Colaborador { get; set; }
    }
}
