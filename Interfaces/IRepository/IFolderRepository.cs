using DocumentinAPI.Domain.DTOs.Folder;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IFolderRepository
    {

        public Task<Retorno<FolderResponseDTO>> GetFolderByIdAsync(int folderId, UserSession ssn);
        public Task<Retorno<ICollection<FolderResponseDTO>>> GetListFolderAsync(UserSession ssn);
        public Task<Retorno<FolderResponseDTO>> AddFolderAsync(FolderRequestDTO dto, UserSession ssn);
        public Task<Retorno<FolderResponseDTO>> UpdateFolderAsync(FolderRequestDTO dto, UserSession ssn);
        public Task<Retorno<FolderResponseDTO>> ToogleStatusFolderAsync(int folderId, UserSession ssn);

    }
}
