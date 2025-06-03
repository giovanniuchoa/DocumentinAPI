namespace DocumentinAPI.Domain.DTOs.Supabase
{

    /// <summary>
    /// DTO de Requisição para fazer Upload de imagem na nuvem.
    /// </summary>
    public class UploadImageRequestDTO
    {
        /// <summary>
        /// Imagem que será salva.
        /// </summary>        
        public IFormFile Image { get; set; }

    }
}
