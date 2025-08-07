using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IDocumentValidationService
    {

        public Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationAsync(UserClaimDTO ssn);

    }
}
