namespace DocumentinAPI.Domain.DTOs.DocumentVersion
{
    public class DocumentVersionResponseDTO
    {

        public int DocumentVersionId { get; set; }

        public int DocumentId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        public string Comment { get; set; }

    }
}
