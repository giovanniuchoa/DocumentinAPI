namespace DocumentinAPI.Domain.DTOs.DocumentValidation
{

    /// <summary>
    /// DTO de Validação de Documentos atualização.
    /// </summary>
    public class DocumentValidationRequestDTO
    {

        /// <summary>
        /// Identificador do documento.
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Status da validação do documento. (0 - 1 - 2)
        /// </summary>
        public short Status { get; set; }

    }
}
