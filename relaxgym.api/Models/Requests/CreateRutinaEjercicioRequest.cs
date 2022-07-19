using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class CreateRutinaEjercicioRequest
    {
        [Required]
        public int IdEjercicio { get; set; }
        [Required]
        public int CantidadRepeticiones { get; set; }
        [Required]
        public int Series { get; set; }
    }
}
