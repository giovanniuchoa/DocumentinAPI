using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.PasswordRecovery
{

    /// <summary>
    /// DTO para requisição de recuperação de senha.
    /// </summary>
    public class PasswordRecoveryRequestDTO
    {

        /// <summary>
        /// Email do usuário para recuperação de senha.
        /// </summary>
        public string Email { get; set; }

    }
}
