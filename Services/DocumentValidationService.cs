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



    }
}
