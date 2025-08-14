namespace DocumentinAPI.Domain.DTOs.Comment
{
    public class CommentResponseDTO
    {

        public int CommentId { get; set; }
        public string Content { get; set; }
        public int DocumentId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
