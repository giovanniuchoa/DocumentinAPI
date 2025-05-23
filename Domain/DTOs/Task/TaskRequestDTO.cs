using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.DTOs.Task
{
    public class TaskRequestDTO
    {

        public int? TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public short Priority { get; set; }

        public short Status { get; set; }

        public int AssigneeId { get; set; } /* Assinalado para */

        public int? ParentTaskId { get; set; }

    }
}
