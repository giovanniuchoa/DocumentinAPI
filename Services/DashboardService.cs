using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Services
{
    public class DashboardService : IDashboardService
    {

        private readonly IDashboardRepositoy _repository;

        public DashboardService(IDashboardRepositoy repositoy)
        {
            _repository = repositoy;
        }

        public async Task<Retorno<DocumentDashboardResponseDTO>> GetDocumentDashboardInfoAsync(DocumentDashboardRequestDTO dto, UserClaimDTO ssn)
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
    }
}
