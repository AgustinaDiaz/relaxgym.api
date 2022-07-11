using System.Collections.Generic;

namespace relaxgym.api.Entities
{
    public class Rutina
    {
        public int Id { get; set; }
        public string IdWeb { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadRondas { get; set; }
        public string Nivel { get; set; }
        public virtual ICollection<UsuarioRutina> Usuarios { get; set; }
        public virtual ICollection<EjercicioRutina> Ejercicios { get; set; }
    }
}