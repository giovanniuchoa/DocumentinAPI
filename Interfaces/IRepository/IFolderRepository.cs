using DocumentinAPI.Domain.DTOs.Folder;
using DocumentinAPI.Domain.DTOs.FolderXGroup;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IFolderRepository
    {

        public Task<Retorno<FolderResponseDTO>> GetFolderByIdAsync(int folderId, UserClaimDTO ssn);
        public Task<Retorno<ICollection<FolderResponseDTO>>> GetListFolderAsync(UserClaimDTO ssn);
        public Task<Retorno<FolderResponseDTO>> AddFolderAsync(FolderRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<FolderResponseDTO>> UpdateFolderAsync(FolderRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<FolderResponseDTO>> ToogleStatusFolderAsync(int folderId, UserClaimDTO ssn);
        public Task<Retorno<FolderResponseDTO>> MoveFolderAsync(MoveFolderRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> AddFolderXGroupAsync(FolderXGroupRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<GroupResponseDTO>>> DeleteFolderXGroupAsync(FolderXGroupRequestDTO dto, UserClaimDTO ssn);

    }
}
