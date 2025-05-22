using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.DTOs.Task
{
    public class TaskResponseDTO
    {

        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public short Priority { get; set; }

        public short Status { get; set; }

        public int AssigneeId { get; set; } /* Assinalado para */

        public int UserId { get; set; } /* Criado por */

        public int ParentTaskId { get; set; }

        public bool IsActive { get; set; }

    }
}
