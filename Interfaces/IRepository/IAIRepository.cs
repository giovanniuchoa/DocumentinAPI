using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.LogAPIRequest;
using DocumentinAPI.Domain.DTOs.OpenAIConfig;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IAIRepository
    {

        public Task LogAIRequestAsync(LogAIRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<OpenAIConfigResponseDTO>> GetOpenAIConfigByIdAsync(int openAiConfigId, UserClaimDTO ssn);
        public Task<Retorno<OpenAIConfigResponseDTO>> AddOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<OpenAIConfigResponseDTO>> UpdateOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn);
    }
}
