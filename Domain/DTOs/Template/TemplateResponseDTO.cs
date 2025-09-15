using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Template
{
    public class TemplateResponseDTO
    {

        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
