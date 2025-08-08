using DocumentinAPI.Domain.DTOs.Document;
using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.DocumentValidation
{
    public class DocumentValidationResponseDTO
    {

        public int DocumentValidationId { get; set; }

        public int DocumentId { get; set; }

        public int FolderId { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        public string Comment { get; set; }

        public DocumentResponseDTO Document { get; set; }

    }
}
