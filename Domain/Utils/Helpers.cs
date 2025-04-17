using System.Security.Cryptography;

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

    }
}
