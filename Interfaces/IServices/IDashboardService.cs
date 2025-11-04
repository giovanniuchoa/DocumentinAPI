using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IDashboardService
    {

        public Task<Retorno<DocumentDashboardResponseDTO>> GetDocumentDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);

    }
}
