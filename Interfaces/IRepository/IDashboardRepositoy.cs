using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.DocumentValidation;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IDashboardRepositoy
    {

        public Task<Retorno<DocumentDashboardResponseDTO>> GetDocumentDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<List<DocumentMonthDashResponseDTO>>> GetDocumentMonthDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<AIDashboardResponseDTO>> GetAIDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<List<AIUsageDashboardResponseDTO>>> GetAIUsersUsageDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<TaskDashResponseDTO>> GetTaskInfoDashAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<List<TaskPriorityDashResponseDTO>>> GetTaskPriorityDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<DocumentValidationDashResponseDTO>> GetDocumentValidationDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<List<DocumentValidationUserDashResponseDTO>>> GetDocumentValidationUsersDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn);

    }
}
