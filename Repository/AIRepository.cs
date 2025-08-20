using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class AIRepository : BaseRepository, IAIRepository
    {

        public AIRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<AIResponseDTO>> GenerateSummaryAsync(AIRequestDTO dto, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }
    }
}
