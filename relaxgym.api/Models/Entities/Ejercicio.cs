using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace relaxgym.api.Entities
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string IdWeb { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlEjercicio { get; set; }
        public int IdTipoEjercicio { get; set; }
        public virtual TipoEjercicio TipoEjercicio { get; set; }
        [JsonIgnore]
        public virtual ICollection<EjercicioRutina> Rutinas { get; set; }
    }
}
