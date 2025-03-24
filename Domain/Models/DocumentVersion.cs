using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class DocumentVersion
    {

        [Key]
        public int DocumentVersionId { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Comment { get; set; }

    }
}
