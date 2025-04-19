using DocumentinAPI.Interfaces.IServices;
using MailKit.Net.Smtp;
using MimeKit;

namespace DocumentinAPI.Services
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            
            try
            {

                var email = new MimeMessage();
                var smtpServer = _config["Email:SmtpServer"];
                var smtpPort = int.Parse(_config["Email:Port"]);
                var from = _config["Email:From"];
                var appPassword = _config["Email:AppPassword"];

                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(from, appPassword);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
