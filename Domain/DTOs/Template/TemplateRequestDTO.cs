namespace DocumentinAPI.Domain.DTOs.Template
{

    /// <summary>
    /// DTO de Template para requisições de criação ou atualização.
    /// </summary>
    public class TemplateRequestDTO
    {

        /// <summary>
        /// Identificador do Template. Deve ser nulo para criação de um novo Template.
        /// </summary>
        public int? TemplateId { get; set; }

        /// <summary>
        /// Nome do Template.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Conteúdo ou estrutura base do Template.
        /// </summary>
        public string Content { get; set; }

    }
}
