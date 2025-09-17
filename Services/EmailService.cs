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

        public async Task SendEmailDocumentValidationStatusChange(string email, DocumentValidationStatusEmailTemplateDTO dto)
        {

            try
            {

                var status = dto.Status == (short)Enums.StatusValidacao.Validado ? "APROVADO" : "REJEITADO";

                var body = await MontarEmailBodyStatusValidacaoDocumento(dto);

                await _repository.SendEmailAsync(email, $"Documento {status}", body);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SendEmailNewDocumentToCreator(string email, DocumentEmailTemplateDTO dto)
        {

            try
            {

                var body = await MontarEmailBodyNovoDocumento_Criador(dto);

                await _repository.SendEmailAsync(email, "Novo Documento - Aguardando aprovação", body);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SendEmailNewDocumentToValidator(string email, DocumentEmailTemplateDTO dto)
        {

            try
            {

                var body = await MontarEmailBodyNovoDocumento_Validador(dto);

                await _repository.SendEmailAsync(email, "Novo Documento - Aguardando aprovação", body);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SendEmailPasswordRecovery(string email, PasswordRecoveryEmailTemplateDTO dto)
        {

            try
            {

                var body = await MontarEmailPasswordRecovery(dto);

                await _repository.SendEmailAsync(email, "Recuperação de Senha - Token", body);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
