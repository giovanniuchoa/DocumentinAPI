using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.DocumentValidation;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IDocumentValidationService
    {

        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationByValidatorAsync(UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationToEditAsync(UserClaimDTO ssn);
        public Task<Retorno<DocumentValidationResponseDTO>> UpdateDocumentValidationStatusAsync(DocumentValidationRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<DocumentValidationResponseDTO>> GetDocumentValidationByIdAsync(int documentId, UserClaimDTO ssn);

    }
}
