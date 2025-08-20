using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.Utils;
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

        public async Task<Retorno<AIResponseDTO>> GenerateSummaryAsync(AIRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<AIResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GenerateSummaryAsync(dto, ssn);

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
