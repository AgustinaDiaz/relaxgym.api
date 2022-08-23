using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class AsignarTurnoRequest
    {
        [Required]
        public int IdTurno { get; set; }
        [Required]
        public IList<int> IdUsuarios { get; set; }
    }
}
