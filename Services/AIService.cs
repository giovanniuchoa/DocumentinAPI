using DocumentinAPI.Domain.DTOs.AI;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.DTOs.LogAPIRequest;
using DocumentinAPI.Domain.DTOs.OpenAIConfig;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using System.Text;
using System.Text.Json;

namespace DocumentinAPI.Services
{
    public class AIService : IAIService
    {

        private readonly IAIRepository _repository;


        private readonly IConfiguration _config;

        public AIService(IAIRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
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

                var apiKey = (await _repository.GetOpenAIConfigByCompanyAsync(ssn))?.Objeto?.ApiKey;

                if (apiKey == null)
                {
                    throw new Exception("apiKeyRequired");
                }

                var model = _config["OpenAI:Model"];
                var baseUrl = _config["OpenAI:BaseUrl"];

                var client = new HttpClient();

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                var body = new
                {
                    model = model,
                    messages = new[]
                    {
                        new { role = "system", content = "Você receberá um texto estruturado em XML e deve sempre responder apenas com o conteúdo em XML resumido, mantendo o formato XML válido." },
                        new { role = "user", content = dto.Content }
                    }
                };

                var json = JsonSerializer.Serialize(body);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}/chat/completions", content);

                if (!response.IsSuccessStatusCode)
                {
                    oRetorno.SetErro("errorCallingOpenAI");
                }


                var responseString = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(responseString);

                int tokensEnviados = response.IsSuccessStatusCode ? doc.RootElement.GetProperty("usage").GetProperty("prompt_tokens").GetInt32() : 0;
                int tokensRecebidos = response.IsSuccessStatusCode ? doc.RootElement.GetProperty("usage").GetProperty("completion_tokens").GetInt32() : 0;

                var resumo = doc.RootElement
                                .GetProperty("choices")[0]
                                .GetProperty("message")
                                .GetProperty("content")
                                .GetString();

                oRetorno.Objeto = new AIResponseDTO { Content = resumo };
                oRetorno.SetSucesso();

                logDTO.RequestJson = json;
                logDTO.ResponseJson = responseString;
                logDTO.RequestTokens = tokensEnviados;
                logDTO.ResponseTokens = tokensRecebidos;

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
    }
}
