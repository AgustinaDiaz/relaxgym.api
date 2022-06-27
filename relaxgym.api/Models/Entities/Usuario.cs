using System.Collections.Generic;

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
        public int IdEstadoUsuario { get; set; }
        public virtual EstadoUsuario EstadoUsuario { get; set; }
        public virtual ICollection<UsuarioTurno> Turnos { get; set; }
        public virtual ICollection<UsuarioRutina> Rutinas { get; set; }
        public int IdRol { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
