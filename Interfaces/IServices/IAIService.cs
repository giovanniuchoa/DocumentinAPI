using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IAIService
    {

        public Task<Retorno<AIResponseDTO>> GenerateSummaryAsync(AIRequestDTO dto, UserClaimDTO ssn);

    }
}
