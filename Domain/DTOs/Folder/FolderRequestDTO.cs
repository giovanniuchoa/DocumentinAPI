using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Folder
{
    public class FolderRequestDTO
    {

        public int? FolderId { get; set; }

        public string Name { get; set; }

        public int? ParentFolderId { get; set; }

    }
}
