using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDocumentVersionRepository
    {

        public Task<Retorno<DocumentVersionResponseDTO>> GetDocumentVersionByIdAsync(int documentVersionId, UserSession ssn);
        public Task<Retorno<ICollection<DocumentVersionResponseDTO>>> GetDocumentVersionsByDocumentIdAsync(int documentId, UserSession ssn);
        public Task<Retorno<DocumentVersionResponseDTO>> AddDocumentVersionAsync(DocumentVersionRequestDTO dto, UserSession ssn);
        public Task<Retorno<DocumentVersionResponseDTO>> AddCommentDocumentVersionAsync(DocumentVersionAddCommentRequestDTO dto, UserSession ssn);

    }
}
