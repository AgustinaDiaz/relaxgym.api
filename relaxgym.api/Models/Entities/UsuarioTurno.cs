using System.Text.Json.Serialization;

namespace relaxgym.api.Entities
{
    public class UsuarioTurno
    {
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        [JsonIgnore]
        public int IdTurno { get; set; }
        [JsonIgnore]
        public virtual Turno Turno { get; set; }
    }
}
