using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpeCar.GestionDocumental.Models.Entities
{
    public class EArea
    {
        public int IdArea { get; set; }
        public int IdTipoArea { get; set; }
        public string UrlImg { get; set; }
        public string Descripcion { get; set; }
        public int IdHistorial { get; set; }
    }
    
}