using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class PasswordRecovery
    {

        [Key]
        [Required]
        public int PasswordRecoveryId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(6)")]
        public string Token { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
