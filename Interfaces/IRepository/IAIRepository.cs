using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.LogAPIRequest;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IAIRepository
    {

        public Task LogAIRequestAsync(LogAIRequestDTO dto, UserClaimDTO ssn);

    }
}
