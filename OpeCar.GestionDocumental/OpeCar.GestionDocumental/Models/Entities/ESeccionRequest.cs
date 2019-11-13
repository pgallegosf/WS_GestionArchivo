namespace OpeCar.GestionDocumental.Models.Entities
{
    public class ESeccionRequest
    {
        public int? IdSeccion { get; set; }
        public short IdTipoSeccion { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string RutaMultimedia { get; set; }
        public int Posicion { get; set; }
        public int IdUsuario { get; set; }
        public bool IndicadorHabilitado { get; set; }
        
    }
}