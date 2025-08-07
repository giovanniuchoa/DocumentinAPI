using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class DocumentValidationService : IDocumentValidationService
    {

        private readonly IDocumentValidationRepository _repository;

        public DocumentValidationService(IDocumentValidationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<DocumentResponseDTO>> oRetorno = new();

            try
            {
                var ret = await _repository.GetListDocumentValidationAsync(ssn);
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
