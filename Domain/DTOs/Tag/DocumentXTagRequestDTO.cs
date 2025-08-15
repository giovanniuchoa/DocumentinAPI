using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Tag
{

    /// <summary>
    /// DTO de DocumentXTag para requisições de criação ou delete.
    /// </summary>
    public class DocumentXTagRequestDTO
    {

        /// <summary>
        /// Identificador da Tag.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Identificador do Documento.
        /// </summary>
        public int DocumentId { get; set; }

    }
}
