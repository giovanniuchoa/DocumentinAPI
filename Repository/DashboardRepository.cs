using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.DocumentValidation;
using DocumentinAPI.Domain.DTOs.Task;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class DashboardRepository : BaseRepository, IDashboardRepositoy
    {

        public DashboardRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<AIDashboardResponseDTO>> GetAIDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<AIDashboardResponseDTO> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@DataInicio", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@DataFim", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<AIDashboardResponseDTO>(
                        "EXEC spGetIAInfoDash @DataInicio, @DataFim, @CompanyId",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret.FirstOrDefault();
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<List<AIUsageDashboardResponseDTO>>> GetAIUsersUsageDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<List<AIUsageDashboardResponseDTO>> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@DataInicio", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@DataFim", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<AIUsageDashboardResponseDTO>(
                        "EXEC spGetUserUsageIAInfoDash @DataInicio, @DataFim, @CompanyId",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret;
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentDashboardResponseDTO>> GetDocumentDashboardInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentDashboardResponseDTO> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@CreatedAtFrom", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@CreatedAtTo", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<DocumentDashboardResponseDTO>(
                        "EXEC spGetDocumentsInfoDash @CompanyId, @CreatedAtFrom, @CreatedAtTo",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret.FirstOrDefault();
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<List<DocumentMonthDashResponseDTO>>> GetDocumentMonthDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<List<DocumentMonthDashResponseDTO>> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@DataInicio", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@DataFim", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<DocumentMonthDashResponseDTO>(
                        "EXEC spDocumentsByMonthDash @DataInicio, @DataFim, @CompanyId",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret;
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentValidationDashResponseDTO>> GetDocumentValidationDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentValidationDashResponseDTO> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@CreatedAtFrom", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@CreatedAtTo", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<DocumentValidationDashResponseDTO>(
                        "EXEC spDocumentValidationsDash @CompanyId, @CreatedAtFrom, @CreatedAtTo",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret.FirstOrDefault();
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<List<DocumentValidationUserDashResponseDTO>>> GetDocumentValidationUsersDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<List<DocumentValidationUserDashResponseDTO>> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@DataInicio", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@DataFim", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<DocumentValidationUserDashResponseDTO>(
                        "EXEC spDocumentValidationUsersDash @CompanyId, @DataInicio, @DataFim",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret;
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TaskDashResponseDTO>> GetTaskInfoDashAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TaskDashResponseDTO> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@CreatedAtFrom", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@CreatedAtTo", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<TaskDashResponseDTO>(
                        "EXEC spTasksDashboard @CompanyId, @CreatedAtFrom, @CreatedAtTo",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret.FirstOrDefault();
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<List<TaskPriorityDashResponseDTO>>> GetTaskPriorityDashInfoAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<List<TaskPriorityDashResponseDTO>> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@DataInicio", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@DataFim", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<TaskPriorityDashResponseDTO>(
                        "EXEC spTasksPrioritiesDashboard @CompanyId, @DataInicio, @DataFim",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret;
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<List<UserActivityDashResponseDTO>>> GetUserActivityDashAsync(DashboardRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<List<UserActivityDashResponseDTO>> oRetorno = new();

            try
            {
                var companyIdParam = new SqlParameter("@CompanyId", ssn.CompanyId);
                var createdAtFromParam = new SqlParameter("@DataInicio", dto.CreatedAtFrom ?? (object)DBNull.Value);
                var createdAtToParam = new SqlParameter("@DataFim", dto.CreatedAtTo ?? (object)DBNull.Value);

                var ret = await _context.Database
                    .SqlQueryRaw<UserActivityDashResponseDTO>(
                        "EXEC spUserActivityDashboard @CompanyId, @DataInicio, @DataFim",
                        companyIdParam,
                        createdAtFromParam,
                        createdAtToParam
                    )
                    .ToListAsync();

                oRetorno.Objeto = ret;
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
    