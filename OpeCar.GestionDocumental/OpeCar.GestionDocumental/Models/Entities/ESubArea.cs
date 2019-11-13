using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpeCar.GestionDocumental.Models.Entities
{
    public class ESubArea:Base<int>
    {
        
        public int IdArea { get; set; }
        public int? IdPadre { get; set; }
        public int IdHistorial { get; set; }
        public bool EsUltimo { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }
}