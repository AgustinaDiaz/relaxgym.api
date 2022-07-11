using System.Text.Json.Serialization;

namespace relaxgym.api.Entities
{
    public class EjercicioRutina
    {
        public int IdEjercicio { get; set; }
        public virtual Ejercicio Ejercicio { get; set; }
        [JsonIgnore]
        public int IdRutina { get; set; }
        [JsonIgnore]
        public virtual Rutina Rutina { get; set; }
        public int Series { get; set; }
        public int CantidadRepeticiones { get; set; }
    }
}
