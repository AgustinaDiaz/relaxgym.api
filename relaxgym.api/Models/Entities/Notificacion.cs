using System.Collections.Generic;

namespace relaxgym.api.Entities
{
    public class Notificacion
    {
        public int Id { get; set; }
        public string IdWeb { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdEstadoNotificacion { get; set; }
        public virtual EstadoNotificacion EstadoNotificacion { get; set; }
        public int IdTipoNotificacion { get; set; }
        public virtual TipoNotificacion TipoNotificacion { get; set; }
        public virtual ICollection<UsuarioNotificacion> Usuarios { get; set; }
    }
}