using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IAuthService
    {

        public Task<Retorno<AuthResponseDTO>> AuthenticateAsync(AuthRequestDTO model);

    }
}
