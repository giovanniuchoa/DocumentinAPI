using DocumentinAPI.Domain.DTOs.Email;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using static DocumentinAPI.Domain.Utils.TemplateHelpers;

namespace DocumentinAPI.Services
{
    public class EmailService : IEmailService
    {

        private readonly IEmailRepository _repository;

        public EmailService(IEmailRepository repository)
        {
            _repository = repository;
        }

        public void SendEmailDocumentValidationStatusChange(string email, DocumentValidationStatusEmailTemplateDTO dto)
        {

            Task.Run(async () =>
            {

                var status = dto.Status == (short)Enums.StatusValidacao.Validado ? "APROVADO" : dto.Status == (short)Enums.StatusValidacao.Retornado ? "REJEITADO" : "EM VALIDAÇÃO";

                var body = await MontarEmailBodyStatusValidacaoDocumento(dto);

                await _repository.SendEmailAsync(email, $"Documento {status}", body);

            });

        }

        public void SendEmailNewCommentToDocumentCreator(string email, CommentEmailTemplateDTO dto)
        {

            Task.Run(async () =>
            {

                var body = await MontarEmailBodyNovoComentarioNoDocumento(dto);

                await _repository.SendEmailAsync(email, "Novo Comentário no Documento", body);

            });

        }

        public void SendEmailNewDocumentToCreator(string email, DocumentEmailTemplateDTO dto)
        {

            Task.Run(async () =>
            {

                var body = await MontarEmailBodyNovoDocumento_Criador(dto);

                await _repository.SendEmailAsync(email, "Novo Documento - Aguardando aprovação", body);

            });

        }

        public void SendEmailNewDocumentToValidator(string email, DocumentEmailTemplateDTO dto)
        {

            Task.Run(async () =>
            {

                var body = await MontarEmailBodyNovoDocumento_Validador(dto);

                await _repository.SendEmailAsync(email, "Novo Documento - Aguardando aprovação", body);

            });

        }

        public void SendEmailNewTaskToAssignee(string email, TaskEmailTemplateDTO dto)
        {

            Task.Run(async () =>
            {

                var body = await MontarEmailBodyNovaTarefa(dto);

                await _repository.SendEmailAsync(email, "Nova Tarefa", body);

            });

        }

        public void SendEmailPasswordRecovery(string email, PasswordRecoveryEmailTemplateDTO dto)
        {

            Task.Run(async () =>
            {

                var body = await MontarEmailPasswordRecovery(dto);

                await _repository.SendEmailAsync(email, "Recuperação de Senha - Token", body);

            });

        }
    }
}
