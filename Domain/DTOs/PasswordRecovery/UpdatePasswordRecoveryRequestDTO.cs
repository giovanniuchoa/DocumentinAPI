using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.PasswordRecovery
{

    /// <summary>
    /// DTO para requisição de atualização de senha.
    /// </summary>
    public class UpdatePasswordRecoveryRequestDTO
    {

        /// <summary>
        /// Email do usuário para o qual a senha será atualizada.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Token de recuperação de senha previamente enviado para o e-mail.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Nova senha que será definida para o usuário.
        /// </summary>
        public string NewPassword { get; set; }

    }
}
