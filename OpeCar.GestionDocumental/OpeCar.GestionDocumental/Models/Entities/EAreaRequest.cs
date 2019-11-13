using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpeCar.GestionDocumental.Models.Entities
{
    public class EAreaRequest:Base<int?>
    {
        
        public int IdTipoArea { get; set; }
        public string UrlImg { get; set; }
        public int IdHistorial { get; set; }
        public int IdUsuario{ get; set; }
        public DateTime FechaTransaccion { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }
}