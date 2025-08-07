using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDocumentValidationRepository
    {

        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationByValidatorAsync(UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationToEditAsync(UserClaimDTO ssn);

    }
}
