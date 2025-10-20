using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IEmbeddingService
    {

        public Task<Retorno<List<float>>> GetEmbeddingAsync(string input, UserClaimDTO ssn);

    }
}
