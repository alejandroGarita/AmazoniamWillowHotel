//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Caracteristica_Habitacion
    {
        public int Id_Caracteristica_Habitacion { get; set; }
        public string Descripcion { get; set; }
        public int Id_Tipo_Habitacion { get; set; }
    
        public virtual Tipo_Habitacion Tipo_Habitacion { get; set; }
    }
}
