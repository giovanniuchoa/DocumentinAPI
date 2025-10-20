using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using OpenAI;
using OpenAI.Embeddings;

namespace DocumentinAPI.Services
{
    public class EmbeddingService : IEmbeddingService
    {

        private readonly IAIRepository _repository;

        private readonly IConfiguration _config;

        public EmbeddingService(IAIRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        public async Task<Retorno<List<float>>> GetEmbeddingAsync(string input, UserClaimDTO ssn)
        {

            var oRetorno = new Retorno<List<float>>();

            try
            {

                var apiKey = ((await _repository.GetOpenAIConfigByCompanyAsync(ssn))?.Objeto?.ApiKey) ?? throw new Exception("apiKeyRequired");

                EmbeddingClient client = new(_config["OpenAI:Embedding"], apiKey);

                OpenAIEmbedding response = client.GenerateEmbedding(input);

                ReadOnlyMemory<float> vector = response.ToFloats();

                oRetorno.Objeto = vector.ToArray().ToList();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
