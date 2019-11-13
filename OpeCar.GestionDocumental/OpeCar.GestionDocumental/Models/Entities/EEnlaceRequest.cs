namespace OpeCar.GestionDocumental.Models.Entities
{
    public class EEnlaceRequest
    {
        public int? IdEnlace { get; set; }
        public string Descripcion { get; set; }
        public string UrlEnlace { get; set; }
        public string ImgEnlace { get; set; }
        public int IdUsuario { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }
}