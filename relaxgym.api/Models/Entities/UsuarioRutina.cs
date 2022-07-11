using System.Text.Json.Serialization;

namespace relaxgym.api.Entities
{
    public class UsuarioRutina
    {
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        public int IdRutina { get; set; }
        [JsonIgnore]
        public virtual Rutina Rutina { get; set; }
        public string Observacion { get; set; }
    }
}
