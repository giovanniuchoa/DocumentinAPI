using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserSession ssn)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetUserByIdAsync(userId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserSession ssn)
        {

            Retorno<IEnumerable<UserResponseDTO>> oRetorno = new();
            try
            {

                var ret = await _repository.GetListUserAsync(ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
