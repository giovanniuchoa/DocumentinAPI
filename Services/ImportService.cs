using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Import;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class ImportService : IImportService
    {

        private readonly IImportRepository _repository;

        public ImportService(IImportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<DocumentResponseDTO>> ImportDocumentAsync(ImportRequestDTO dto, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }
    }
}
