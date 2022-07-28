using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace relaxgym.api.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string IdWeb { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public decimal Telefono { get; set; }
        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdEstadoUsuario { get; set; }
        public virtual EstadoUsuario EstadoUsuario { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsuarioTurno> Turnos { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsuarioRutina> Rutinas { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsuarioNotificacion> Notificaciones { get; set; }
        public int IdRol { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
