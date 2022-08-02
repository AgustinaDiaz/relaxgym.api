using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class CreateNotificacionRequest
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int IdTipoNotificacion { get; set; }
        [Required]
        public int[] IdUsuarios { get; set; }
    }
}
