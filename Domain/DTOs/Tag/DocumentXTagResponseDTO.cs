using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Tag
{
    public class DocumentXTagResponseDTO
    {

        public int TagId { get; set; }
        public int DocumentId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
