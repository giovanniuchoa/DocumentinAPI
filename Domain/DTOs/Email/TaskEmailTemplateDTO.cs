namespace DocumentinAPI.Domain.DTOs.Email
{
    public class TaskEmailTemplateDTO
    {

        public string AssigneeName { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }

    }
}
