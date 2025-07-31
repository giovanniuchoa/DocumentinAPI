using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDocumentVersionRepository
    {

        public Task<Retorno<DocumentVersionResponseDTO>> GetDocumentVersionByIdAsync(int documentVersionId, UserClaimDTO ssn);
        public Task<Retorno<ICollection<DocumentVersionResponseDTO>>> GetDocumentVersionsByDocumentIdAsync(int documentId, UserClaimDTO ssn);
        public Task<Retorno<DocumentVersionResponseDTO>> AddDocumentVersionAsync(DocumentVersionRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<DocumentVersionResponseDTO>> AddCommentDocumentVersionAsync(DocumentVersionAddCommentRequestDTO dto, UserClaimDTO ssn);

    }
}
