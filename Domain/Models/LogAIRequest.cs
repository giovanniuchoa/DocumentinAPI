using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class LogAIRequest
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string RequestJson { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string ResponseJson { get; set; }

        [Required]
        public int RequestTokens { get; set; }

        [Required]
        public int ResponseTokens { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
