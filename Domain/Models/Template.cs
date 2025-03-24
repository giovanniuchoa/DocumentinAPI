using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class Template
    {

        [Key]
        public int TemplateId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]  
        public string Content { get; set; }

    }
}
