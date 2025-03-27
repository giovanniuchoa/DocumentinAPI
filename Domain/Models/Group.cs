using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class Group
    {

        [Key]
        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
