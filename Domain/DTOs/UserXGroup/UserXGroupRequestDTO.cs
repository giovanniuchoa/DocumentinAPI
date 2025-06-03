using Swashbuckle.AspNetCore.Annotations;


namespace DocumentinAPI.Domain.DTOs.UserXGroup
{

    /// <summary>
    /// DTO para víncular um Usuário a um Grupo.
    /// </summary>
    public class UserXGroupRequestDTO
    {

        /// <summary>
        /// Identificador do Usuário.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Identificador do Grupo.
        /// </summary>
        public int GroupId { get; set; }

    }
}
