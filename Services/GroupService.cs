using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Services
{
    public class GroupService : IGroupService
    {

        private readonly IGroupRepository _repository;

        public GroupService(IGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<GroupResponseDTO>> GetGroupByIdAsync(int groupId, UserClaimDTO ssn)
        {

            Retorno<GroupResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetGroupByIdAsync(groupId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListGroupAsync(UserClaimDTO ssn)
        {
            
            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.GetListGroupAsync(ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

            }

        public async Task<Retorno<GroupResponseDTO>> AddGroupAsync(GroupRequestDTO group, UserClaimDTO ssn)
        {

            Retorno<GroupResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddGroupAsync(group, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;
            
        }

        public async Task<Retorno<GroupResponseDTO>> UpdateGroupAsync(GroupRequestDTO group, UserClaimDTO ssn)
        {

            Retorno<GroupResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdateGroupAsync(group, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<GroupResponseDTO>> ToggleStatusGroupAsync(int groupId, UserClaimDTO ssn)
        {

            Retorno<GroupResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.ToggleStatusGroupAsync(groupId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserXGroupByGroupAsync(int groupId, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<UserResponseDTO>> oRetorno = new();

            try
            {
                var ret = await _repository.GetListUserXGroupByGroupAsync(groupId, ssn);

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
