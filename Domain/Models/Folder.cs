using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class Folder
    {

        [Key]
        public int FolderId { get; set; }

        [Required]
        public string Name { get; set; }

        public int ParentFolderId { get; set; }

    }
}
