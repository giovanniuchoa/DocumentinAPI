using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class Document
    {

        [Key]   
        public int DocumentId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Format { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FolderId { get; set; }

    }
}
