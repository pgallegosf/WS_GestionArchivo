//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoArea
    {
        public TipoArea()
        {
            this.Area = new HashSet<Area>();
        }
    
        public int IdTipoArea { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Area> Area { get; set; }
    }
}
