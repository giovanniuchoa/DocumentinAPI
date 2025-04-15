using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        [Required]
        public short Profile { get; set; }

        public short PreferredLanguage { get; set; }

        public short PreferredTheme { get; set; }

        [Required]  
        public DateTime CreatedAt { get; set; }

        [Required]  
        public DateTime UpdatedAt { get; set; }

        public DateTime? LastLoginAt { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]  
        public bool IsActive { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }

    }
}
