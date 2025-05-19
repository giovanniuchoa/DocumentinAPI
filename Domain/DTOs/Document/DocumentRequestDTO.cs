namespace DocumentinAPI.Domain.DTOs.Document
{
    public class DocumentRequestDTO
    {

        public int? DocumentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int FolderId { get; set; }

    }
}
