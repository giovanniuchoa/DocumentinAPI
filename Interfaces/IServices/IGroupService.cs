using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IGroupService
    {

        public Task<Retorno<GroupResponseDTO>> GetGroupByIdAsync(int groupId, UserSession ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListGroupAsync(UserSession ssn);
        public Task<Retorno<GroupResponseDTO>> AddGroupAsync(GroupRequestDTO group, UserSession ssn);
        public Task<Retorno<GroupResponseDTO>> UpdateGroupAsync(GroupRequestDTO group, UserSession ssn);
        public Task<Retorno<GroupResponseDTO>> ToggleStatusGroupAsync(int groupId, UserSession ssn);
        public Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserXGroupByGroupAsync(int groupId, UserSession ssn);


    }
}
