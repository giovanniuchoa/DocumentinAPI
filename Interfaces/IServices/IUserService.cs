using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.DTOs.UserXGroup;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IUserService
    {

        public Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserClaimDTO ssn);
        public Task<Retorno<UserResponseDTO>> AddUserAsync(UserRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<UserResponseDTO>> UpdateUserAsync(UserRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<UserResponseDTO>> ToggleStatusUserAsync(int userId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListUserXGroupByUserAsync(int userId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> AddUserXGroupAsync(UserXGroupRequestDTO model, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> DeleteUserXGroupAsync(UserXGroupRequestDTO model, UserClaimDTO ssn);
        public Task<Retorno<PasswordRecoveryResponseDTO>> RequestPasswordRecoveryAsync(PasswordRecoveryRequestDTO model);
        public Task<Retorno<ValidatePasswordRecoveryResponseDTO>> ValidateTokenPasswordRecoveryAsync(ValidatePasswordRecoveryRequestDTO model);
        public Task<Retorno<UserResponseDTO>> UpdatePasswordRecoveryAsync(UpdatePasswordRecoveryRequestDTO model);

    }
}
