using System;
using System.Collections.Generic;

namespace relaxgym.api.Entities
{
    public class Turno
    {
        public int Id { get; set; }
        public string IdWeb { get; set; }
        public int IdClase { get; set; }
        public virtual Clase Clase { get; set; }
        public int CantidadAlumnos { get; set; }
        public DateTime FechaHora { get; set; }
        public ICollection<UsuarioTurno> Usuarios { get; set; }
    }
}
