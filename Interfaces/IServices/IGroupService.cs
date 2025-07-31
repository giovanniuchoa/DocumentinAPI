using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IGroupService
    {

        public Task<Retorno<GroupResponseDTO>> GetGroupByIdAsync(int groupId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListGroupAsync(UserClaimDTO ssn);
        public Task<Retorno<GroupResponseDTO>> AddGroupAsync(GroupRequestDTO group, UserClaimDTO ssn);
        public Task<Retorno<GroupResponseDTO>> UpdateGroupAsync(GroupRequestDTO group, UserClaimDTO ssn);
        public Task<Retorno<GroupResponseDTO>> ToggleStatusGroupAsync(int groupId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserXGroupByGroupAsync(int groupId, UserClaimDTO ssn);


    }
}
