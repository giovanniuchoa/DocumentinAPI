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

        private readonly IDocumentService _documentService;

        private readonly IConfiguration _config;

        private readonly HttpClient _client;

        public AIService(IAIRepository repository, IConfiguration config, IDocumentService documentService, IHttpClientFactory clientFactory)
        {
            _repository = repository;
            _config = config;
            _documentService = documentService;
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

                var contentDB = await _documentService.GetDocumentByIdAsync(dto.DocumentId, ssn);            

                OpenAIRequestDTO body = BuildRequestBody(contentDB.Objeto.Content, dto.Model);

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

        private OpenAIRequestDTO BuildRequestBody(string documentContent, short model)
        {

            var prompt = "";

            switch (model)
            {
                case (short)Enums.OpenAIModels.ResumoEstruturado:
                    prompt = "Você receberá um documento em formato Markdown. Resuma o conteúdo em tópicos curtos e objetivos, mantendo apenas as informações essenciais. A resposta deve ser devolvida exclusivamente em formato Markdown válido, preservando a estrutura hierárquica com títulos e subtítulos.";

                    break;

                case (short)Enums.OpenAIModels.ResumoComparativo:
                    prompt = "Você receberá um texto em formato Markdown contendo comparações, listas ou discussões. Resuma apenas os pontos de contraste ou semelhança principais. A resposta deve ser devolvida somente em formato Markdown válido, sem adicionar explicações ou comentários.";

                    break;

                case (short)Enums.OpenAIModels.ResumoAnalitico:
                    prompt = "Você receberá um documento em formato Markdown. Crie uma versão resumida que destaque as ideias centrais e suas relações lógicas. A resposta deve ser devolvida em Markdown válido, mantendo a hierarquia e eliminando exemplos ou explicações desnecessárias.";

                    break;

                default:
                    prompt = "Você recebera um documento em formato Markdown. Sua tarefa eh devolver uma versao resumida somente em Markdown valido, sem explicacoes ou comentarios. Mantenha a hierarquia, preserve apenas informacoes essenciais e reduza detalhes irrelevantes.";

                    break;
            }

            return new OpenAIRequestDTO
            {
                Model = _config["OpenAI:Model"],
                Messages =
                [
                    new ChatMessageDTO 
                    { 
                        Role = "system",
                        Content = prompt
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
