using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace DocumentinAPI.Domain.Models
{
    public class Document
    {

        [Key]   
        public int DocumentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Content { get; set; }

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

        public Nullable<bool> IsValid { get; set; }

        [Required]
        public string EmbeddingJson { get; set; } = string.Empty;

        [NotMapped]
        public List<float> Embedding
        {
            get => string.IsNullOrEmpty(EmbeddingJson)
                ? new List<float>()
                : JsonSerializer.Deserialize<List<float>>(EmbeddingJson)!;

            set => EmbeddingJson = JsonSerializer.Serialize(value);
        }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(FolderId))]
        public virtual Folder Folder { get; set; }

    }
}
