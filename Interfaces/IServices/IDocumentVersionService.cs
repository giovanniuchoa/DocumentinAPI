using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IDocumentVersionService
    {

        public Task<Retorno<DocumentVersionResponseDTO>> GetDocumentVersionByIdAsync(int documentVersionId, UserSession ssn);
        public Task<Retorno<ICollection<DocumentVersionResponseDTO>>> GetDocumentVersionsByDocumentIdAsync(int documentId, UserSession ssn);
        public Task<Retorno<DocumentVersionResponseDTO>> AddDocumentVersionAsync(DocumentVersionRequestDTO dto, UserSession ssn);

    }
}
