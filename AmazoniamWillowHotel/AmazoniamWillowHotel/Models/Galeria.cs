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
    
    public partial class Galeria
    {
        public int Id_Galeria { get; set; }
        public string Imagen { get; set; }
        public int Id_Estado { get; set; }
    
        public virtual Estado Estado { get; set; }
    }
}
