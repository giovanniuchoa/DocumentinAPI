namespace DocumentinAPI.Domain.DTOs.Email
{
    public class DocumentValidationStatusEmailTemplateDTO
    {

        public string Title { get; set; }
        public short Status { get; set; }
        public string ValidatorName { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FolderName { get; set; }

    }
}
