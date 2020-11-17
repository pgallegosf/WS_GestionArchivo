using System;

namespace OpeCar.GestionDocumental.Models.Entities
{
    public class ELog
    {
        public long IDLog { get; set; }
        public string Usuario { get; set; }
        public string TipoLog { get; set; }
        public string Funcion { get; set; }
        public string RegistroLog { get; set; }
        public string RequestLog { get; set; }
        public DateTime FechaLog { get; set; }
        
    }
}