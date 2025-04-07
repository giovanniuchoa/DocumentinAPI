using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Adress { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
