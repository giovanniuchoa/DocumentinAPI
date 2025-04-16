using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.DTOs.UserXGroup;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IUserService
    {

        public Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserSession ssn);
        public Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserSession ssn);
        public Task<Retorno<UserResponseDTO>> AddUserAsync(UserRequestDTO dto, UserSession ssn);
        public Task<Retorno<UserResponseDTO>> UpdateUserAsync(UserRequestDTO dto, UserSession ssn);
        public Task<Retorno<UserResponseDTO>> ToggleStatusUserAsync(int userId, UserSession ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListUserXGroupByUserAsync(int userId, UserSession ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> PostUserXGroupAsync(UserXGroupRequestDTO model, UserSession ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> DeleteUserXGroupAsync(UserXGroupRequestDTO model, UserSession ssn);

    }
}
