using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IDocumentVersionService
    {

        public Task<Retorno<DocumentVersionResponseDTO>> GetDocumentVersionByIdAsync(int documentVersionId, UserClaimDTO ssn);
        public Task<Retorno<ICollection<DocumentVersionResponseDTO>>> GetDocumentVersionsByDocumentIdAsync(int documentId, UserClaimDTO ssn);
        public Task<Retorno<DocumentVersionResponseDTO>> AddDocumentVersionAsync(DocumentVersionRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<DocumentVersionResponseDTO>> AddCommentDocumentVersionAsync(DocumentVersionAddCommentRequestDTO dto, UserClaimDTO ssn);

    }
}
