using DocumentinAPI.Domain.DTOs.Email;
using DocumentinAPI.Domain.Models;
using Supabase.Gotrue;

namespace DocumentinAPI.Domain.Utils
{
    public static class TemplateHelpers
    {

        public static async Task<string> GetEmailBodyFromTemplateAsync(string templateFileName, Dictionary<string, string> replacements)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", templateFileName);
            var html = await File.ReadAllTextAsync(filePath);

            foreach (var item in replacements)
            {
                html = html.Replace($"{{{{{item.Key}}}}}", item.Value);
            }

            return html;
        }

        public static async Task<string> MontarEmailPasswordRecovery(PasswordRecoveryEmailTemplateDTO dto)
        {

            var dados = new Dictionary<string, string>
            {
                { "NOME", dto.Name },
                { "TOKEN", dto.Token }
            };

            var body = await GetEmailBodyFromTemplateAsync("PasswordRecovery.html", dados);

            return body;

        }

        public static async Task<string> MontarEmailBodyNovoDocumento_Validador(DocumentEmailTemplateDTO dto)
        {

            var dados = new Dictionary<string, string>
            {
                { "TITULO", dto.Title },
                { "CRIADOR", dto.Username },
                { "PASTA", dto.FolderName },
                { "DATA_CRIACAO", dto.CreatedAt.ToString() }
            };

            var body = await GetEmailBodyFromTemplateAsync("NewDocumentValidator.html", dados);

            return body;

        }

        public static async Task<string> MontarEmailBodyNovoDocumento_Criador(DocumentEmailTemplateDTO dto)
        {

            var dados = new Dictionary<string, string>
            {
                { "TITULO", dto.Title },
                { "VALIDADOR", dto.Username },
                { "PASTA", dto.FolderName },
                { "DATA_CRIACAO", dto.CreatedAt.ToString() }
            };

            var body = await GetEmailBodyFromTemplateAsync("NewDocumentCreator.html", dados);

            return body;

        }

        public static async Task<string> MontarEmailBodyStatusValidacaoDocumento(DocumentValidationStatusEmailTemplateDTO dto)
        {

            var status = dto.Status == (short)Enums.StatusValidacao.Validado ? "APROVADO" : dto.Status == (short)Enums.StatusValidacao.Retornado ? "REJEITADO" : "EM VALIDAÇÃO";

            var dados = new Dictionary<string, string>
            {
                { "TITULO", dto.Title },
                { "VALIDADOR", dto.ValidatorName },
                { "PASTA", dto.FolderName },
                { "DATA_ATUALIZACAO", dto.UpdatedAt.ToString() },
                { "STATUS", status },
                { "COR_STATUS", status == "APROVADO" ?  "#28a745" : "#dc3545"}
            };

            var body = await GetEmailBodyFromTemplateAsync("UpdateDocumentValidationStatus.html", dados);

            return body;

        }

        public static async Task<string> MontarEmailBodyNovaTarefa(TaskEmailTemplateDTO dto)
        {

            var dados = new Dictionary<string, string>
            {
                { "USUARIO", dto.AssigneeName },
                { "TITULO", dto.Title },
                { "DATA_ENTREGA", dto.DueDate.ToString() },
                { "DESCRICAO", dto.Description }
            };

            var body = await GetEmailBodyFromTemplateAsync("NewTaskAssignee.html", dados);

            return body;

        }

        public static async Task<string> MontarEmailBodyNovoComentarioNoDocumento(CommentEmailTemplateDTO dto)
        {

            var dados = new Dictionary<string, string>
            {
                { "CRIADOR", dto.UserDocument },
                { "COMENTARISTA", dto.UserComment },
                { "TITULO_DOCUMENTO", dto.DocumentTitle },
                { "COMENTARIO", dto.Comment },
                { "DATA_COMENTARIO", dto.CommentDate.ToString() }
            };

            var body = await GetEmailBodyFromTemplateAsync("NewCommentDocumentCreator.html", dados);

            return body;

        }

    }
}
