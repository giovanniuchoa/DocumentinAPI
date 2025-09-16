using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DocumentinAPI.Domain.Utils
{
    public static class Helpers
    {

        public static string GerarTokenNumerico(int digitos)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            int numero = BitConverter.ToInt32(bytes, 0) & 0x7FFFFFFF;
            numero %= (int)Math.Pow(10, digitos);
            return numero.ToString($"D{digitos}");
        }

        public static string TratarMarkdown(string markdown)
        {

            string pattern = @"!\[[^\]]*\]\([^)]+\)";

            var matches = Regex.Matches(markdown, pattern);

            if (matches.Count > 1)
            {
                var match = matches[0];

                markdown = markdown.Remove(match.Index, match.Length);
            }

            markdown = markdown.Replace($"**Evaluation Only. Created with Aspose.Words. Copyright 2003-2025 Aspose Pty Ltd.**", $"");
            markdown = markdown.Replace($"**Created with an evaluation copy of Aspose.Words. To remove all limitations, you can use Free Temporary License [https://products.aspose.com/words/temporary-license/**](https://products.aspose.com/words/temporary-license/)**", $"");
            markdown = markdown.Replace($"**This document was truncated here because it was created in the Evaluation Mode.**", $"");

            markdown = Regex.Replace(markdown, @"!\[[^\]]*\]", "![]");

            return markdown;

        }

    }
}
