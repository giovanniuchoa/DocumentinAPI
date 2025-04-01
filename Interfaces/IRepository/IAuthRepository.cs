using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IAuthRepository
    {

        public Task<Retorno<AuthResponseDTO>> AuthenticateAsync(AuthRequestDTO model);

    }
}
