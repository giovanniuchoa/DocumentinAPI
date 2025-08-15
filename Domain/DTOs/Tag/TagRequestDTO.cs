namespace DocumentinAPI.Domain.DTOs.Tag
{

    /// <summary>
    /// DTO de Tag para requisições de criação ou atualização.
    /// </summary>
    public class TagRequestDTO
    {

        /// <summary>
        /// Identificador da Tag.
        /// </summary>
        public int? TagId { get; set; }

        /// <summary>
        /// Nome da Tag.
        /// </summary>
        public string Name { get; set; }

    }
}
