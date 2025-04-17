namespace DocumentinAPI.Domain.DTOs.PasswordRecovery
{
    public class ValidatePasswordRecoveryRequestDTO
    {

        public string Email { get; set; }

        public string Token { get; set; }

    }
}
