using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Tag;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface ITagService
    {

        public Task<Retorno<TagResponseDTO>> GetTagByIdAsync(int tagId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<TagResponseDTO>>> GetListTagAsync(UserClaimDTO ssn);
        public Task<Retorno<TagResponseDTO>> AddTagAsync(TagRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<TagResponseDTO>> UpdateTagAsync(TagRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<TagResponseDTO>> ToogleStatusTagAsync(int tagId, UserClaimDTO ssn);
        public Task<Retorno<DocumentXTagResponseDTO>> AddDocumentXTagAsync(DocumentXTagRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<TagResponseDTO>>> DeleteDocumentXTagAsync(DocumentXTagRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<TagResponseDTO>>> GetDocumentXTagByDocumentIdAsync(int documentId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetDocumentXTagByTagIdAsync(int tagId, UserClaimDTO ssn);

    }
}
