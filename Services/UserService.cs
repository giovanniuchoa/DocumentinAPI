using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.DTOs.UserXGroup;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Domain.DTOs.Auth;
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

        public async Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserClaimDTO ssn)
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

        public async Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserClaimDTO ssn)
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

        public async Task<Retorno<UserResponseDTO>> AddUserAsync(UserRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                if (ssn.Profile == 2 && dto.Profile == 1)
                {
                    throw new Exception("noPermission"); 
                }

                var ret = await _repository.AddUserAsync(dto, ssn); 

                oRetorno= ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<UserResponseDTO>> UpdateUserAsync(UserRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                if (ssn.Profile == 2 && dto.Profile == 1)
                {
                    throw new Exception("noPermission");
                }

                var ret = await _repository.UpdateUserAsync(dto, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<UserResponseDTO>> ToggleStatusUserAsync(int userId, UserClaimDTO ssn)
        {

            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.ToggleStatusUserAsync(userId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListUserXGroupByUserAsync(int userId, UserClaimDTO ssn)
        {
            
            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.GetListUserXGroupByUserAsync(userId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> AddUserXGroupAsync(UserXGroupRequestDTO model, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.AddUserXGroupAsync(model, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> DeleteUserXGroupAsync(UserXGroupRequestDTO model, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.DeleteUserXGroupAsync(model, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<PasswordRecoveryResponseDTO>> RequestPasswordRecoveryAsync(PasswordRecoveryRequestDTO model)
        {
            
            Retorno<PasswordRecoveryResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.RequestPasswordRecoveryAsync(model);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<ValidatePasswordRecoveryResponseDTO>> ValidateTokenPasswordRecoveryAsync(ValidatePasswordRecoveryRequestDTO model)
        {
            
            Retorno<ValidatePasswordRecoveryResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.ValidateTokenPasswordRecoveryAsync(model);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<UserResponseDTO>> UpdatePasswordRecoveryAsync(UpdatePasswordRecoveryRequestDTO model)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdatePasswordRecoveryAsync(model);

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
