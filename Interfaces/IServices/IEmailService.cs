using DocumentinAPI.Domain.DTOs.Email;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface IEmailService
    {

        public void SendEmailNewDocumentToValidator(string email, DocumentEmailTemplateDTO dto);
        public void SendEmailNewDocumentToCreator(string email, DocumentEmailTemplateDTO dto);
        public void SendEmailPasswordRecovery(string email, PasswordRecoveryEmailTemplateDTO dto);
        public void SendEmailDocumentValidationStatusChange(string email, DocumentValidationStatusEmailTemplateDTO dto);
        public void SendEmailNewTaskToAssignee(string email, TaskEmailTemplateDTO dto);
        public void SendEmailNewCommentToDocumentCreator(string email, CommentEmailTemplateDTO dto);

    }
}
