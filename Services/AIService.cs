using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class AIService : IAIService
    {

        private readonly IAIRepository _repository;

        public AIService(IAIRepository repository)
        {
            _repository = repository;
        }

    }
}
