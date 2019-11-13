using System;

namespace OpeCar.GestionDocumental.Models.Entities
{
    public class EEnlace
    {
        public int IdEnlace { get; set; }
        public string Descripcion { get; set; }
        public string UrlEnlace { get; set; }
        public string ImgEnlace { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}