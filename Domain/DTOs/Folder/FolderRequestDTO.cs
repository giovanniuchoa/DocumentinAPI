using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Folder
{

    /// <summary>
    /// DTO de Pasta para requisições de criação ou atualização.
    /// </summary>
    public class FolderRequestDTO
    {

        /// <summary>
        /// Identificador da pasta. Deve ser nulo para criação de uma nova pasta.
        /// </summary>
        public int? FolderId { get; set; }

        /// <summary>
        /// Nome da pasta.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identificador da pasta pai, caso houver.
        /// </summary>
        public int? ParentFolderId { get; set; }

    }
}
