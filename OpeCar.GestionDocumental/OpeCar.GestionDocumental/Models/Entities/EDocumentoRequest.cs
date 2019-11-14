using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpeCar.GestionDocumental.Models.Entities
{
    public class EDocumentoRequest : Base<int?>
    {
        public int IdSubArea { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public int? IdHistorico { get; set; }
        public string UrlDocumento { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }
}