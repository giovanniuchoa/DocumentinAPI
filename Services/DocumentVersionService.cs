using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class DocumentVersionService : IDocumentVersionService
    {

        private readonly IDocumentVersionRepository _repository;

        public DocumentVersionService(IDocumentVersionRepository repository)
        {
            _repository = repository;
        }

    }
}
