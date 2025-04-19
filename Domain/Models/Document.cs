using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class Document
    {

        [Key]   
        public int DocumentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Content { get; set; }

        [Column(TypeName = "char(5)")]
        public string Format { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FolderId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(FolderId))]
        public virtual Folder Folder { get; set; }

    }
}
