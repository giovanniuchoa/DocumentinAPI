using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Dashboard;
using DocumentinAPI.Domain.DTOs.Document;
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
            throw new NotImplementedException();
        }
    }
}
    