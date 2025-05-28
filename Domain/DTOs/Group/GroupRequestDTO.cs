using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.Group
{

    /// <summary>
    /// DTO de Grupo para requisições de criação ou atualização.
    /// </summary>
    public class GroupRequestDTO
    {

        /// <summary>
        /// Identificador do grupo. Deve ser nulo para criação de um novo grupo.
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// Nome do grupo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do grupo.
        /// </summary>
        public string Description { get; set; }

    }
}
