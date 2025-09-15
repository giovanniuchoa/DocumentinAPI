namespace DocumentinAPI.Domain.DTOs.Import
{
    public class ImportRequestDTO
    {

        public IFormFile Pdf { get; set; }

        public int FolderId { get; set; }

    }
}
