using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.Document
{

    /// <summary>
    /// DTO de Documento para requisições de criação ou atualização.
    /// </summary>
    public class DocumentRequestDTO
    {

        /// <summary>
        /// Identificador do Documento. Necessário apenas para atualizações.
        /// </summary>
        public int? DocumentId { get; set; }

        /// <summary>
        /// Título do Documento.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Conteúdo (HTML) do Documento.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Identificador da Pasta onde o Documento será armazenado.
        /// </summary>
        public int FolderId { get; set; }

    }
}
