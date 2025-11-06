namespace DocumentinAPI.Domain.DTOs.Task
{
    public class TaskDashResponseDTO
    {

        public int TotalTasks { get; set; }
        public decimal CompletionRate { get; set; }
        public int TotalLate { get; set; }
        public int TotalCompleted { get; set; }

    }
}
