using System.Threading.Tasks;

namespace relaxgym.api.Services
{
    public interface IMailSenderService
    {
        Task<bool> SendEmailSolicitudCambioPasswordAsync(string toEmail, string nombreUsuario, string idWebSolicitud);
        Task<bool> SendEmailBienvenidaAsync(string toEmail, string nombreUsuario, string password, string nombreCompleto);
    }
}
