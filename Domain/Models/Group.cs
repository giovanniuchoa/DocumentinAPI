using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class Group
    {

        [Key]
        public int GroupId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
