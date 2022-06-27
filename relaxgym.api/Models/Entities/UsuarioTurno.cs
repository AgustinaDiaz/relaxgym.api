namespace relaxgym.api.Entities
{
    public class UsuarioTurno
    {
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int IdTurno { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
