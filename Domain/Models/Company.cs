using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Adress { get; set; }

    }
}
