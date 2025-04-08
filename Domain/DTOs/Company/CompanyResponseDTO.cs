using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Company
{
    public class CompanyResponseDTO
    {

        public int? CompanyId { get; set; }

        public string Name { get; set; }

        public string TaxId { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string ZipCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
