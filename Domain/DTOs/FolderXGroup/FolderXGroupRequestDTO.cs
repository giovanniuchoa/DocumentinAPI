namespace DocumentinAPI.Domain.DTOs.FolderXGroup
{

    /// <summary>
    /// DTO para víncular uma Pasta a um Grupo.
    /// </summary>
    public class FolderXGroupRequestDTO
    {

        /// <summary>
        /// Identificador da Pasta.
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        /// Identificador do Grupo.
        /// </summary>
        public int GroupId { get; set; }

    }
}
