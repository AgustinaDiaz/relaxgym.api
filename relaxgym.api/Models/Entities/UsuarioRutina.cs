namespace relaxgym.api.Entities
{
    public class UsuarioRutina
    {
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int IdRutina { get; set; }
        public virtual Rutina Rutina { get; set; }
    }
}
