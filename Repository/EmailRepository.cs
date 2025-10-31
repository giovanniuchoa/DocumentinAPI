using DocumentinAPI.Interfaces.IRepository;
using MailKit.Net.Smtp;
using MimeKit;

namespace DocumentinAPI.Repository
{
    public class EmailRepository : IEmailRepository
    {

        private readonly IConfiguration _config;

        public EmailRepository(IConfiguration config)
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

                Console.WriteLine(smtpPort);
                Console.WriteLine(smtpServer);
                Console.WriteLine(email);
                Console.WriteLine(from);
                Console.WriteLine(appPassword);

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
