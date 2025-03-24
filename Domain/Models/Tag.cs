using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class Tag
    {

        [Key]
        public int TagId { get; set; }

        [Required]  
        public string Name { get; set; }

    }
}
