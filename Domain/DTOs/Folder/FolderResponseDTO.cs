using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Folder
{
    public class FolderResponseDTO
    {

        public int FolderId { get; set; }

        public string Name { get; set; }

        public int? ParentFolderId { get; set; }

        public int UserId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
