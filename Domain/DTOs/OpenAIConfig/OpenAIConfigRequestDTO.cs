namespace DocumentinAPI.Domain.DTOs.OpenAIConfig
{

    /// <summary>
    /// DTO de configuração de OpenAI.
    /// </summary>
    public class OpenAIConfigRequestDTO
    {

        /// <summary>
        /// identificador da configuração do OpenAI.
        /// </summary>
        public int? OpenAIConfigId { get; set; }

        /// <summary>
        /// Chave da API do OpenAI.
        /// </summary>
        public string ApiKey { get; set; }

    }
}
