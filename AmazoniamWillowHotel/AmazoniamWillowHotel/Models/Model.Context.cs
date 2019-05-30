﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
        public virtual DbSet<Caracteristica> Caracteristica { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Imagen> Imagen { get; set; }
        public virtual DbSet<Info> Info { get; set; }
        public virtual DbSet<Pagina> Pagina { get; set; }
        public virtual DbSet<Promocion> Promocion { get; set; }
        public virtual DbSet<Publicidad> Publicidad { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }
        public virtual DbSet<Tipo_Habitacion> Tipo_Habitacion { get; set; }
    
        public virtual ObjectResult<sp_AvailabilityDay_Result> sp_AvailabilityDay()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AvailabilityDay_Result>("sp_AvailabilityDay");
        }
    
        public virtual ObjectResult<sp_check_Rooms_Available_Result> sp_check_Rooms_Available(Nullable<System.DateTime> llegada, Nullable<System.DateTime> salida, Nullable<int> tipo)
        {
            var llegadaParameter = llegada.HasValue ?
                new ObjectParameter("llegada", llegada) :
                new ObjectParameter("llegada", typeof(System.DateTime));
    
            var salidaParameter = salida.HasValue ?
                new ObjectParameter("salida", salida) :
                new ObjectParameter("salida", typeof(System.DateTime));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_check_Rooms_Available_Result>("sp_check_Rooms_Available", llegadaParameter, salidaParameter, tipoParameter);
        }
    
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
    
        public virtual ObjectResult<sp_insertImage_Result> sp_insertImage(string nombre, byte[] imagen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("imagen", imagen) :
                new ObjectParameter("imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_insertImage_Result>("sp_insertImage", nombreParameter, imagenParameter);
        }
    
        public virtual ObjectResult<sp_makeReservation_Result> sp_makeReservation(string identificacion, string nombre, string apellidos, string correo, string tarjeta, string fechaVencimiento, string codigoSeguridad, Nullable<int> numero, Nullable<System.DateTime> fechaLlegada, Nullable<System.DateTime> fechaSalida, Nullable<double> monto)
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
    
            var fechaVencimientoParameter = fechaVencimiento != null ?
                new ObjectParameter("fechaVencimiento", fechaVencimiento) :
                new ObjectParameter("fechaVencimiento", typeof(string));
    
            var codigoSeguridadParameter = codigoSeguridad != null ?
                new ObjectParameter("codigoSeguridad", codigoSeguridad) :
                new ObjectParameter("codigoSeguridad", typeof(string));
    
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            var fechaLlegadaParameter = fechaLlegada.HasValue ?
                new ObjectParameter("fechaLlegada", fechaLlegada) :
                new ObjectParameter("fechaLlegada", typeof(System.DateTime));
    
            var fechaSalidaParameter = fechaSalida.HasValue ?
                new ObjectParameter("fechaSalida", fechaSalida) :
                new ObjectParameter("fechaSalida", typeof(System.DateTime));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_makeReservation_Result>("sp_makeReservation", identificacionParameter, nombreParameter, apellidosParameter, correoParameter, tarjetaParameter, fechaVencimientoParameter, codigoSeguridadParameter, numeroParameter, fechaLlegadaParameter, fechaSalidaParameter, montoParameter);
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
    
        public virtual int FreeRoom(Nullable<int> numero)
        {
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FreeRoom", numeroParameter);
        }
    
        public virtual ObjectResult<MakeReservation_Result> MakeReservation(string identificacion, string nombre, string apellidos, string correo, string tarjeta, string fechaVencimiento, string codigoSeguridad, Nullable<int> numero, Nullable<System.DateTime> fechaLlegada, Nullable<System.DateTime> fechaSalida, Nullable<double> monto)
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
    
            var fechaVencimientoParameter = fechaVencimiento != null ?
                new ObjectParameter("fechaVencimiento", fechaVencimiento) :
                new ObjectParameter("fechaVencimiento", typeof(string));
    
            var codigoSeguridadParameter = codigoSeguridad != null ?
                new ObjectParameter("codigoSeguridad", codigoSeguridad) :
                new ObjectParameter("codigoSeguridad", typeof(string));
    
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            var fechaLlegadaParameter = fechaLlegada.HasValue ?
                new ObjectParameter("fechaLlegada", fechaLlegada) :
                new ObjectParameter("fechaLlegada", typeof(System.DateTime));
    
            var fechaSalidaParameter = fechaSalida.HasValue ?
                new ObjectParameter("fechaSalida", fechaSalida) :
                new ObjectParameter("fechaSalida", typeof(System.DateTime));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MakeReservation_Result>("MakeReservation", identificacionParameter, nombreParameter, apellidosParameter, correoParameter, tarjetaParameter, fechaVencimientoParameter, codigoSeguridadParameter, numeroParameter, fechaLlegadaParameter, fechaSalidaParameter, montoParameter);
        }
    
        public virtual ObjectResult<CheckRoomsAvailable_Result> CheckRoomsAvailable(Nullable<System.DateTime> llegada, Nullable<System.DateTime> salida, Nullable<int> tipo)
        {
            var llegadaParameter = llegada.HasValue ?
                new ObjectParameter("llegada", llegada) :
                new ObjectParameter("llegada", typeof(System.DateTime));
    
            var salidaParameter = salida.HasValue ?
                new ObjectParameter("salida", salida) :
                new ObjectParameter("salida", typeof(System.DateTime));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CheckRoomsAvailable_Result>("CheckRoomsAvailable", llegadaParameter, salidaParameter, tipoParameter);
        }
    
        public virtual ObjectResult<sp_roomDay_Result> getRoomsDay()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_roomDay_Result>("getRoomsDay");
        }
    
        public virtual ObjectResult<sp_getTypes_Result> sp_getTypes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getTypes_Result>("sp_getTypes");
        }
    
        public virtual int sp_insertPromotion(string descripcion, Nullable<int> descuento, Nullable<System.DateTime> inicio, Nullable<System.DateTime> fin, Nullable<int> tipoH)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var descuentoParameter = descuento.HasValue ?
                new ObjectParameter("descuento", descuento) :
                new ObjectParameter("descuento", typeof(int));
    
            var inicioParameter = inicio.HasValue ?
                new ObjectParameter("inicio", inicio) :
                new ObjectParameter("inicio", typeof(System.DateTime));
    
            var finParameter = fin.HasValue ?
                new ObjectParameter("fin", fin) :
                new ObjectParameter("fin", typeof(System.DateTime));
    
            var tipoHParameter = tipoH.HasValue ?
                new ObjectParameter("tipoH", tipoH) :
                new ObjectParameter("tipoH", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insertPromotion", descripcionParameter, descuentoParameter, inicioParameter, finParameter, tipoHParameter);
        }
    
        public virtual ObjectResult<sp_getPromotions_Result> sp_getPromotions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPromotions_Result>("sp_getPromotions");
        }
    
        public virtual ObjectResult<sp_getPromotions_Result> getPromotion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPromotions_Result>("getPromotion");
        }
    
        public virtual ObjectResult<sp_getPromotion_Result> sp_getPromotion(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPromotion_Result>("sp_getPromotion", idParameter);
        }
    
        public virtual int sp_deletePromotion(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deletePromotion", idParameter);
        }
    }
}
