namespace DocumentinAPI.Authentication
{
    public static class Settings
    {
        /* TODO: Mudar para variável de ambiente JWT_SECRET */
        public static string Secret = Environment.GetEnvironmentVariable("JWT_SECRET");
    }
}
