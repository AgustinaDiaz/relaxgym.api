using System;

namespace relaxgym.api.Entities
{
    public class SolicitudCambioPassword
    {
        public int Id { get; set; }
        public string IdWeb { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public string AntiguaClave { get; set; }
        public string NuevaClave { get; set; }
        public int IdEstadoSolicitud { get; set; }
        public virtual EstadoSolicitud EstadoSolicitud { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
