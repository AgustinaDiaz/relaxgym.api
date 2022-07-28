using System.Text.Json.Serialization;

namespace relaxgym.api.Entities
{
    public class UsuarioNotificacion
    {
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        [JsonIgnore]
        public int IdNotificacion { get; set; }
        [JsonIgnore]
        public virtual Notificacion Notificacion { get; set; }
    }
}
