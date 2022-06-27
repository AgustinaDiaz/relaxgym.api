using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class UpdateUsuarioRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public decimal Telefono { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string ClaveUsuario { get; set; }
        [Required]
        public int IdEstadoUsuario { get; set; }
        [Required]
        public int IdRol { get; set; }
    }
}