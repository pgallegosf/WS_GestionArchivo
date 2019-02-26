using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpeCar.GestionDocumental.Models.Entities
{
    public class ESubAreaRequest:Base<int?>
    {
        public int IdArea { get; set; }
        public int? IdPadre { get; set; }
        public int IdHistorial { get; set; }
        public bool EsUltimo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }
}