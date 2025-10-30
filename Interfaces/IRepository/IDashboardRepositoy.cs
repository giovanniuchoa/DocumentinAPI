using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDashboardRepositoy
    {

        public Task<Retorno<DocumentDashboardResponseDTO>> GetDocumentDashboardInfoAsync(DocumentDashboardRequestDTO dto, UserClaimDTO ssn);

    }
}
