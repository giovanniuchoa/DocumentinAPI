using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Company
{
    public class CompanyResponseDTO
    {

        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        public bool IsActive { get; set; }

    }
}
