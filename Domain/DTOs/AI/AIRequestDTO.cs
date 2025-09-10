namespace DocumentinAPI.Domain.DTOs.AI
{

    /// <summary>
    /// DTO de conteúdo de documento para resumo via IA.
    /// </summary>
    public class AIRequestDTO
    {

        /// <summary>
        /// Identificador documento a ser resumido.
        /// </summary>
        public int DocumentId { get; set; }

    }
}
