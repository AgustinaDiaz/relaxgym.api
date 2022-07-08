using System.Threading.Tasks;

namespace relaxgym.api.Services
{
    public interface IMailSenderService
    {
        Task<bool> SendEmailAsync(string toEmail, string nombreUsuario, string idWebSolicitud);
    }
}
