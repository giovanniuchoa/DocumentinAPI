using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IUserService
    {

        public Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserSession ssn);
        public Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserSession ssn);
        public Task<Retorno<UserResponseDTO>> AddUserAsync(UserRequestDTO dto, UserSession ssn);
        public Task<Retorno<UserResponseDTO>> UpdateUserAsync(UserRequestDTO dto, UserSession ssn);
        public Task<Retorno<UserResponseDTO>> DeleteUserAsync(int userId, UserSession ssn);


    }
}
