using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class Task
    {

        [Key]
        public int TaskId { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public short Priority { get; set; }

        [Required]
        public short Status { get; set; }

        public int AssigneeId { get; set; } /* Assinalado para */

        [Required]
        public int UserId { get; set; } /* Criado por */

        public int ParentTaskId { get; set; }

        [ForeignKey(nameof(AssigneeId))]
        public virtual User Assignee { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(ParentTaskId))]
        public virtual Task ParentTask { get; set; }

    }
}
