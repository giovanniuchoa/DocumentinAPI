using System.Security.Cryptography;
using System.Text;

namespace DocumentinAPI.Cryptography
{
    public static class Hash
    {

        public static string GenerateHash(this string pass)
        {
            using var hash = SHA256.Create();
            var encoding = new UTF8Encoding();
            var array = encoding.GetBytes(pass);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }

    }
}
