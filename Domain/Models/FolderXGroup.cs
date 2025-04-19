using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class FolderXGroup
    {

        [Required]  
        public int FolderId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(FolderId))]
        public virtual Folder Folder { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }

    }
}
