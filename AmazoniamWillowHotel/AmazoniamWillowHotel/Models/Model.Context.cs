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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
    
        public virtual ObjectResult<sp_checkAvailability_Result> sp_checkAvailability(Nullable<int> idTipoHabitacion, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin)
        {
            var idTipoHabitacionParameter = idTipoHabitacion.HasValue ?
                new ObjectParameter("idTipoHabitacion", idTipoHabitacion) :
                new ObjectParameter("idTipoHabitacion", typeof(int));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("fechaInicio", fechaInicio) :
                new ObjectParameter("fechaInicio", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("fechaFin", fechaFin) :
                new ObjectParameter("fechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_checkAvailability_Result>("sp_checkAvailability", idTipoHabitacionParameter, fechaInicioParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<sp_freeRoom_Result> sp_freeRoom(Nullable<int> numero)
        {
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_freeRoom_Result>("sp_freeRoom", numeroParameter);
        }
    
        public virtual ObjectResult<sp_getFacilities_Result> sp_getFacilities()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getFacilities_Result>("sp_getFacilities");
        }
    
        public virtual ObjectResult<sp_getPagaForName_Result> sp_getPagaForName(string nombre_Pagina)
        {
            var nombre_PaginaParameter = nombre_Pagina != null ?
                new ObjectParameter("Nombre_Pagina", nombre_Pagina) :
                new ObjectParameter("Nombre_Pagina", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPagaForName_Result>("sp_getPagaForName", nombre_PaginaParameter);
        }
    
        public virtual ObjectResult<sp_getStatus_Result> sp_getStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getStatus_Result>("sp_getStatus");
        }
    
        public virtual int sp_insertFacilitie(string descripcion, string imagen, Nullable<int> id_Estado)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var id_EstadoParameter = id_Estado.HasValue ?
                new ObjectParameter("Id_Estado", id_Estado) :
                new ObjectParameter("Id_Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insertFacilitie", descripcionParameter, imagenParameter, id_EstadoParameter);
        }
    
        public virtual ObjectResult<sp_makeReservation_Result> sp_makeReservation(string identificacion, string nombre, string apellidos, string correo, string tarjeta, Nullable<int> numero, Nullable<System.DateTime> fechaLlegada, Nullable<System.DateTime> fechaSalida)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("apellidos", apellidos) :
                new ObjectParameter("apellidos", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var tarjetaParameter = tarjeta != null ?
                new ObjectParameter("tarjeta", tarjeta) :
                new ObjectParameter("tarjeta", typeof(string));
    
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            var fechaLlegadaParameter = fechaLlegada.HasValue ?
                new ObjectParameter("fechaLlegada", fechaLlegada) :
                new ObjectParameter("fechaLlegada", typeof(System.DateTime));
    
            var fechaSalidaParameter = fechaSalida.HasValue ?
                new ObjectParameter("fechaSalida", fechaSalida) :
                new ObjectParameter("fechaSalida", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_makeReservation_Result>("sp_makeReservation", identificacionParameter, nombreParameter, apellidosParameter, correoParameter, tarjetaParameter, numeroParameter, fechaLlegadaParameter, fechaSalidaParameter);
        }
    
        public virtual ObjectResult<CheckAvailability_Result> CheckAvailability(Nullable<int> idTipoHabitacion, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin)
        {
            var idTipoHabitacionParameter = idTipoHabitacion.HasValue ?
                new ObjectParameter("idTipoHabitacion", idTipoHabitacion) :
                new ObjectParameter("idTipoHabitacion", typeof(int));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("fechaInicio", fechaInicio) :
                new ObjectParameter("fechaInicio", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("fechaFin", fechaFin) :
                new ObjectParameter("fechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CheckAvailability_Result>("CheckAvailability", idTipoHabitacionParameter, fechaInicioParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<MakeReservation_Result> MakeReservation(string identificacion, string nombre, string apellidos, string correo, string tarjeta, Nullable<int> numero, Nullable<System.DateTime> fechaLlegada, Nullable<System.DateTime> fechaSalida)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("apellidos", apellidos) :
                new ObjectParameter("apellidos", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var tarjetaParameter = tarjeta != null ?
                new ObjectParameter("tarjeta", tarjeta) :
                new ObjectParameter("tarjeta", typeof(string));
    
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            var fechaLlegadaParameter = fechaLlegada.HasValue ?
                new ObjectParameter("fechaLlegada", fechaLlegada) :
                new ObjectParameter("fechaLlegada", typeof(System.DateTime));
    
            var fechaSalidaParameter = fechaSalida.HasValue ?
                new ObjectParameter("fechaSalida", fechaSalida) :
                new ObjectParameter("fechaSalida", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MakeReservation_Result>("MakeReservation", identificacionParameter, nombreParameter, apellidosParameter, correoParameter, tarjetaParameter, numeroParameter, fechaLlegadaParameter, fechaSalidaParameter);
        }
    
        public virtual int FreeRoom(Nullable<int> numero)
        {
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FreeRoom", numeroParameter);
        }
    }
}
