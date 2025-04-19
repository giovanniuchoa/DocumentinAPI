using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class Comment
    {

        [Key]
        public int CommentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Content { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]  
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]  
        public bool IsActive { get; set; }

        [ForeignKey(nameof(DocumentId))]
        public virtual Document Document { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
