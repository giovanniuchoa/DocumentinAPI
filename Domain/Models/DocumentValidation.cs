using Supabase.Gotrue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class DocumentValidation
    {

        [Key]
        public int DocumentValidationId { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public int FolderId { get; set; }

        [Required]
        public short Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(DocumentId))]
        public virtual Document Document { get; set; }

        [ForeignKey(nameof(FolderId))]
        public virtual Folder Folder { get; set; }

    }
}
