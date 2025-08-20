namespace DocumentinAPI.Domain.DTOs.AI
{

    /// <summary>
    /// DTO de conteúdo de documento para resumo via IA.
    /// </summary>
    public class AIRequestDTO
    {

        /// <summary>
        /// Conteúdo do documento a ser resumido.
        /// </summary>
        public string Content { get; set; }

    }
}
