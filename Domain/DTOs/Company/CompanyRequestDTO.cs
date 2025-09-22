using Swashbuckle.AspNetCore.Annotations;

namespace DocumentinAPI.Domain.DTOs.Company
{

    /// <summary>
    /// DTO de Empresa para requisições de criação e atualização.
    /// </summary>
    public class CompanyRequestDTO
    {

        /// <summary>
        /// Identificador da Empresa. Necessário apenas para atualizações.
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Nome da Empresa.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// CNPJ da Empresa.
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// Telefone da Empresa.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// E-mail da Empresa.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Endereço da Empresa.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// CEP da Empresa.
        /// </summary>
        public string ZipCode { get; set; }

    }
}
