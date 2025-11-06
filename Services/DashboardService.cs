using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.DTOs.DocumentValidation;

namespace DocumentinAPI.Services
{
    public class DashboardService : IDashboardService
    {

        private readonly IDashboardRepositoy _repository;

        public DashboardService(IDashboardRepositoy repositoy)
        {
            _repository = repositoy;
        }

        public Task<Retorno<AIDashboardResponseDTO>> GetAIDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
            => _repository.GetAIDashboardInfoAsync(dto, ssn);

        public Task<Retorno<List<AIUsageDashboardResponseDTO>>> GetAIUsersUsageDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
            => _repository.GetAIUsersUsageDashInfoAsync(dto, ssn);

        public async Task<Retorno<DocumentDashboardResponseDTO>> GetDocumentDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentDashboardResponseDTO> oRetorno = new();

            try
            {
                var ret = await _repository.GetDocumentDashboardInfoAsync(dto, ssn);
                oRetorno = ret;
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<List<DocumentMonthDashResponseDTO>>> GetDocumentMonthDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
            => await _repository.GetDocumentMonthDashInfoAsync(dto, ssn);

        public Task<Retorno<DocumentValidationDashResponseDTO>> GetDocumentValidationDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
            => _repository.GetDocumentValidationDashInfoAsync(dto, ssn);

        public Task<Retorno<List<DocumentValidationUserDashResponseDTO>>> GetDocumentValidationUsersDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
            => _repository.GetDocumentValidationUsersDashInfoAsync(dto, ssn);

        public Task<Retorno<TaskDashResponseDTO>> GetTaskInfoDashAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
            => _repository.GetTaskInfoDashAsync(dto, ssn);

        public Task<Retorno<List<TaskPriorityDashResponseDTO>>> GetTaskPriorityDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
            => _repository.GetTaskPriorityDashInfoAsync(dto, ssn);

    }
}
