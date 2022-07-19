using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class AsignarRutinaRequest
    {
        [Required]
        public int IdRutina { get; set; }
        [Required]
        public IList<int> IdUsuarios { get; set; }
        public string Observacion { get; set; }
    }
}
