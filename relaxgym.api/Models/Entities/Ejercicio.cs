namespace relaxgym.api.Entities
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string IdWeb { get; set; }
        public string Descripcion { get; set; }
        public int CantidadRepeticiones { get; set; }
        public byte[] ImagenEjercicio { get; set; }
        public string UrlEjercicio { get; set; }
        public int IdTipoEjercicio { get; set; }
        public virtual TipoEjercicio TipoEjercicio { get; set; }
        public int IdRutina { get; set; }
        public virtual Rutina Rutina { get; set; }
    }
}
