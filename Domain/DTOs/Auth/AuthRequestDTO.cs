using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.Auth
{

    /// <summary>
    /// DTO de authenticação e login de Usuário.
    /// </summary>
    public class AuthRequestDTO
    {

        /// <summary>
        /// Login (email) do usuário
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Password { get; set; }

    }
}
