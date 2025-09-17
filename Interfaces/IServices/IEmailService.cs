using DocumentinAPI.Domain.DTOs.Email;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IEmailService
    {

        public Task SendEmailNewDocumentToValidator(string email, DocumentEmailTemplateDTO dto);
        public Task SendEmailNewDocumentToCreator(string email, DocumentEmailTemplateDTO dto);
        public Task SendEmailPasswordRecovery(string email, PasswordRecoveryEmailTemplateDTO dto);
        public Task SendEmailDocumentValidationStatusChange(string email, DocumentValidationStatusEmailTemplateDTO dto);
        public Task SendEmailNewTaskToAssignee(string email, TaskEmailTemplateDTO dto);

    }
}
