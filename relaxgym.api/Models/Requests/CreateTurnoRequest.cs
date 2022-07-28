using System;
using System.ComponentModel.DataAnnotations;

namespace relaxgym.api.Requests
{
    public class CreateTurnoRequest
    {
        [Required]
        public int CantidadAlumnos { get; set; }
        [Required]
        public int IdClase { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
    }
}
