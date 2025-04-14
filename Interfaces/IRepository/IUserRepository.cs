using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IUserRepository
    {

        public Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserSession ssn);
        public Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserSession ssn);
        public Task<Retorno<UserResponseDTO>> AddUserAsync(UserRequestDTO dto ,UserSession ssn);
        public Task<Retorno<UserResponseDTO>> UpdateUserAsync(UserRequestDTO dto ,UserSession ssn);
        public Task<Retorno<UserResponseDTO>> DeleteUserAsync(int userId, UserSession ssn);

    }
}
