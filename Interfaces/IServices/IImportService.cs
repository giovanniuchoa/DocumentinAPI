using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Import;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IImportService
    {

        public Task<Retorno<DocumentResponseDTO>> ImportDocumentAsync(ImportRequestDTO dto, UserClaimDTO ssn);

    }
}
