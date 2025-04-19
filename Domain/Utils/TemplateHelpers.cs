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

    }
}
