using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication;

namespace DocumentinAPI.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<AuthResponseDTO>> AuthenticateAsync(AuthRequestDTO model)
        {
            return await _repository.AuthenticateAsync(model);
        }
    }
}
