namespace DocumentinAPI.Interfaces.IRepository
{
    public interface IEmailRepository
    {

        public Task SendEmailAsync(string to, string subject, string body);

    }
}
