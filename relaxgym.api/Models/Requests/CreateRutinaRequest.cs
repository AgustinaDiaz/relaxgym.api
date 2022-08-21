using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class CreateRutinaRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Nivel { get; set; }
        [Required]
        public int IdUsuarioCreador { get; set; }
        [Required]
        public IList<CreateRutinaEjercicioRequest> Ejercicios { get; set; }
    }
}
