using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class UpdateEjercicioRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string UrlEjercicio { get; set; }
        [Required]
        public int IdTipoEjercicio { get; set; }
    }
}
