using relaxgym.api.Entities;

namespace relaxgym.api.Services
{
    public interface IUsuariosService
    {
        UserToken Authenticate(Usuario usuario);
    }
}
