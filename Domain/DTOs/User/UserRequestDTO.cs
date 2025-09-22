using Swashbuckle.AspNetCore.Annotations;


namespace DocumentinAPI.Domain.DTOs.User
{

    /// <summary>
    /// DTO de Usuário para requisições de criação e atualização.
    /// </summary>
    public class UserRequestDTO
    {

        /// <summary>
        /// Identificador do usuário. Deve ser nulo para criação de um novo usuário.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Enumerador do perfil do usuário.
        /// </summary>
        public short Profile { get; set; }

        /// <summary>
        /// Enumerador da linguagem preferida do usuário.
        /// </summary>
        public short PreferredLanguage { get; set; }

        /// <summary>
        /// Enumerador do tema de layout preferido do usuário.
        /// </summary>
        public short PreferredTheme { get; set; }

        /// <summary>
        /// Identificador da empresa do usuário
        /// </summary>
        public int CompanyId { get; set; }

    }
}
