using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Models.Requests
{
    public class UpdateNotificacionRequest
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int IdEstadoNotificacion { get; set; }
        [Required]
        public int IdTipoNotificacion { get; set; }
    }
}
