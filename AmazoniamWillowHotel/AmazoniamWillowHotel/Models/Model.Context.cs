﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmazoniamWillowHotel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hotel_Amazonian_WillowEntities : DbContext
    {
        public Hotel_Amazonian_WillowEntities()
            : base("name=Hotel_Amazonian_WillowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Caracteristica_Habitacion> Caracteristica_Habitacion { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Facilidad> Facilidad { get; set; }
        public virtual DbSet<Galeria> Galeria { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Pagina> Pagina { get; set; }
        public virtual DbSet<Publicidad> Publicidad { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Tipo_Habitacion> Tipo_Habitacion { get; set; }
    }
}
