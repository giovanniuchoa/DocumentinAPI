using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Document
{
    public class DocumentResponseDTO
    {

        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int FolderId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> IsValid { get; set; }

    }
}
