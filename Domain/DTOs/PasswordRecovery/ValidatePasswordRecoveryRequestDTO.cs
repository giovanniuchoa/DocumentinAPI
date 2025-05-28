using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.PasswordRecovery
{

    /// <summary>
    /// DTO para validar o token de recuperação de senha previamente envaido por e-mail.
    /// </summary>
    public class ValidatePasswordRecoveryRequestDTO
    {

        /// <summary>
        /// Email do usuário que solicitou a recuperação de senha.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Token previamente enviado por e-mail.
        /// </summary>
        public string Token { get; set; }

    }
}
