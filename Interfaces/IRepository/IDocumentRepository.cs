using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDocumentRepository
    {

        public Task<Retorno<DocumentResponseDTO>> GetDocumentByIdAsync(int documentId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentAsync(UserClaimDTO ssn);
        public Task<Retorno<DocumentResponseDTO>> AddDocumentAsync(DocumentRequestDTO document, UserClaimDTO ssn);
        public Task<Retorno<DocumentResponseDTO>> UpdateDocumentAsync(DocumentRequestDTO document, UserClaimDTO ssn);
        public Task<Retorno<DocumentResponseDTO>> ToogleStatusDocumentAsync(int documentId, UserClaimDTO ssn);

    }
}
