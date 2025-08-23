using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.OpenAIConfig;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IAIService
    {

        public Task<Retorno<AIResponseDTO>> GenerateSummaryAsync(AIRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<OpenAIConfigResponseDTO>> GetOpenAIConfigByIdAsync(int openAiConfigId, UserClaimDTO ssn);
        public Task<Retorno<OpenAIConfigResponseDTO>> AddOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<OpenAIConfigResponseDTO>> UpdateOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn);

    }
}
