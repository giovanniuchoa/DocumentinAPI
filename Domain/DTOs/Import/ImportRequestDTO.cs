namespace DocumentinAPI.Domain.DTOs.Import
{

    /// <summary>
    /// DTO de requisição de importação de Documento.
    /// </summary>
    public class ImportRequestDTO
    {
        /// <summary>
        /// Arquivo a ser importado. PDF ou Docx.
        /// </summary>
        public IFormFile File { get; set; }

        /// <summary>
        /// Identificador da pasta em que o documento será armazenado.
        /// </summary>
        public int FolderId { get; set; }

    }
}
