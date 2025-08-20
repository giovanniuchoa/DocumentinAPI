using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IAIRepository
    {

        public Task<Retorno<AIResponseDTO>> GenerateSummaryAsync(AIRequestDTO dto, UserClaimDTO ssn);

    }
}
