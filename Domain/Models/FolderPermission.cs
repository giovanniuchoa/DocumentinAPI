using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(FolderId))]
        public virtual Folder Folder { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }

    }
}
