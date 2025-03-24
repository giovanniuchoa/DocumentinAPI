using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class UserXGroup
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }

    }
}
