using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class Task
    {

        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public short Priority { get; set; }

        [Required]
        public string Status { get; set; }

        public int AssigneeId { get; set; } /* Assinalado para */

        [Required]
        public int UserId { get; set; } /* Criado por */

        public int ParentTaskId { get; set; }

    }
}
