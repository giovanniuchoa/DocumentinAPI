using DocumentinAPI.Domain.DTOs.Folder;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{

    public class FolderService : IFolderService
    {

        private readonly IFolderRepository _repository;

        public FolderService(IFolderRepository folderRepository)
        {
            _repository = folderRepository;
        }

        public async Task<Retorno<FolderResponseDTO>> GetFolderByIdAsync(int folderId, UserSession ssn)
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

        public async Task<Retorno<ICollection<FolderResponseDTO>>> GetListFolderAsync(UserSession ssn)
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

        public async Task<Retorno<FolderResponseDTO>> AddFolderAsync(FolderRequestDTO dto, UserSession ssn)
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

        public async Task<Retorno<FolderResponseDTO>> UpdateFolderAsync(FolderRequestDTO dto, UserSession ssn)
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

        public async Task<Retorno<FolderResponseDTO>> ToogleStatusFolderAsync(int folderId, UserSession ssn)
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

    }

}
