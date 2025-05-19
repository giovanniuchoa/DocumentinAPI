using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDocumentRepository
    {

        public Task<Retorno<DocumentResponseDTO>> GetDocumentByIdAsync(int documentId, UserSession ssn);
        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentAsync(UserSession ssn);
        public Task<Retorno<DocumentResponseDTO>> AddDocumentAsync(DocumentRequestDTO document, UserSession ssn);
        public Task<Retorno<DocumentResponseDTO>> UpdateDocumentAsync(DocumentRequestDTO document, UserSession ssn);
        public Task<Retorno<DocumentResponseDTO>> ToogleStatusDocumentAsync(int documentId, UserSession ssn);

    }
}
