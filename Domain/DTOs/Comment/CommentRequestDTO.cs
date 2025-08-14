using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Comment
{

    /// <summary>
    /// DTO de Comentário para requisições de criação ou atualização.
    /// </summary>
    public class CommentRequestDTO
    {

        /// <summary>
        /// Identificador do Comentário. Necessário apenas para atualizações.
        /// </summary>
        public int? CommentId { get; set; }

        /// <summary>
        /// Conteúdo do Comentário.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Identificador do Documento o qual o Comentário será vinculado.
        /// </summary>
        public int DocumentId { get; set; }

    }
}
