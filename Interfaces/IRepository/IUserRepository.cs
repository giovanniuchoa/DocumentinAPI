using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IUserRepository
    {

        public Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserSession ssn);
        public Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserSession ssn);

    }
}
