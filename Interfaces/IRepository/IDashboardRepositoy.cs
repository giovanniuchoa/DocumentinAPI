using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDashboardRepositoy
    {

        public Task<Retorno<DocumentDashboardResponseDTO>> GetDocumentDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<List<DocumentMonthDashResponseDTO>>> GetDocumentMonthDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<AIDashboardResponseDTO>> GetAIDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);

    }
}
