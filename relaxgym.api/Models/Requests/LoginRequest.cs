using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class LoginRequest
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string ClaveUsuario { get; set; }
    }
}
