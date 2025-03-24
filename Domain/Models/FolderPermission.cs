using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class FolderPermission
    {

        [Key]
        public int FolderPermissionId { get; set; }

        [Required]  
        public int FolderId { get; set; }

        [Required]
        public int GroupId { get; set; }

    }
}
