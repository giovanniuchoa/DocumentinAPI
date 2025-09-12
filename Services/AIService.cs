using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.DTOs.LogAPIRequest;
using DocumentinAPI.Domain.DTOs.OpenAIConfig;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using Org.BouncyCastle.Asn1.Crmf;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DocumentinAPI.Services
{
    public class AIService : IAIService
    {

        private readonly IAIRepository _repository;

        private readonly IDocumentRepository _documentRepository;

        private readonly IConfiguration _config;

        private readonly HttpClient _client;

        public AIService(IAIRepository repository, IConfiguration config, IDocumentRepository documentRepository, IHttpClientFactory clientFactory)
        {
            _repository = repository;
            _config = config;
            _documentRepository = documentRepository;
            _client = clientFactory.CreateClient();
        }

        public async Task<Retorno<OpenAIConfigResponseDTO>> AddOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<OpenAIConfigResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddOpenAIConfigAsync(dto, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<AIResponseDTO>> GenerateSummaryAsync(AIRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<AIResponseDTO> oRetorno = new();

            LogAIRequestDTO logDTO = new LogAIRequestDTO();

            try
            {

                var apiKey = ((await _repository.GetOpenAIConfigByCompanyAsync(ssn))?.Objeto?.ApiKey) ?? throw new Exception("apiKeyRequired");

                var contentDB = await _documentRepository.GetDocumentByIdAsync(dto.DocumentId, ssn);            

                OpenAIRequestDTO body = BuildRequestBody(contentDB.Objeto.Content);

                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                var response = await _client.PostAsJsonAsync($"{_config["OpenAI:BaseUrl"]}/chat/completions", body);

                if (!response.IsSuccessStatusCode)
                {
                    oRetorno.SetErro("errorCallingOpenAI");
                }

                var responseString = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ChatCompletionResponseDTO>(responseString);

                oRetorno.Objeto = new AIResponseDTO { Content = result?.Choices?.FirstOrDefault()?.Message?.Content };

                logDTO.RequestJson = JsonSerializer.Serialize(body);
                logDTO.ResponseJson = responseString;
                logDTO.RequestTokens = result?.Usage?.PromptTokens ?? 0;
                logDTO.ResponseTokens = result?.Usage?.CompletionTokens ?? 0;

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }
            finally
            {

                await _repository.LogAIRequestAsync(logDTO, ssn);

            }

            return oRetorno;

        }

        public async Task<Retorno<OpenAIConfigResponseDTO>> GetOpenAIConfigByCompanyAsync(UserClaimDTO ssn)
        {

            Retorno<OpenAIConfigResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetOpenAIConfigByCompanyAsync(ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<OpenAIConfigResponseDTO>> UpdateOpenAIConfigAsync(OpenAIConfigRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<OpenAIConfigResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdateOpenAIConfigAsync(dto, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        private OpenAIRequestDTO BuildRequestBody(string documentContent)
        {
            return new OpenAIRequestDTO
            {
                Model = _config["OpenAI:Model"],
                Messages =
                [
                    new ChatMessageDTO 
                    { 
                        Role = "system",
                        Content = "Você recebera um documento em formato Markdown. Sua tarefa eh devolver uma versao resumida somente em Markdown valido, sem explicacoes ou comentarios. Mantenha a hierarquia, preserve apenas informacoes essenciais e reduza detalhes irrelevantes."
                    },
                    new ChatMessageDTO 
                    { 
                        Role = "user", 
                        Content = documentContent 
                    }
                ]
            };
        }

    }
}
