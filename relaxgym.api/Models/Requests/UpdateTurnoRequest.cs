using System;
using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class UpdateTurnoRequest
    {
        [Required]
        public int CantidadAlumnos { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
    }
}
