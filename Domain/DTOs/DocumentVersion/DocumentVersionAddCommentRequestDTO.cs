using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.DocumentVersion
{

    /// <summary>
    /// DTO para adicionar um comentário a uma versão de documento.
    /// </summary>
    public class DocumentVersionAddCommentRequestDTO
    {

        /// <summary>
        /// Identificador da versão do documento.
        /// </summary>
        public int DocumentVersionId { get; set; }

        /// <summary>
        /// Comentário a ser adicionado à versão do documento.
        /// </summary>
        public string Comment { get; set; }

    }
}
