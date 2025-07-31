using DocumentinAPI.Domain.DTOs.Folder;
using DocumentinAPI.Domain.DTOs.FolderXGroup;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Services
{

    public class FolderService : IFolderService
    {

        private readonly IFolderRepository _repository;

        public FolderService(IFolderRepository folderRepository)
        {
            _repository = folderRepository;
        }

        public async Task<Retorno<FolderResponseDTO>> GetFolderByIdAsync(int folderId, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetFolderByIdAsync(folderId, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<ICollection<FolderResponseDTO>>> GetListFolderAsync(UserClaimDTO ssn)
        {

            Retorno<ICollection<FolderResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.GetListFolderAsync(ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<FolderResponseDTO>> AddFolderAsync(FolderRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddFolderAsync(dto, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<FolderResponseDTO>> UpdateFolderAsync(FolderRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdateFolderAsync(dto, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<FolderResponseDTO>> ToogleStatusFolderAsync(int folderId, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.ToogleStatusFolderAsync(folderId, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<FolderResponseDTO>> MoveFolderAsync(MoveFolderRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.MoveFolderAsync(dto, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> AddFolderXGroupAsync(FolderXGroupRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.AddFolderXGroupAsync(dto, ssn);
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
