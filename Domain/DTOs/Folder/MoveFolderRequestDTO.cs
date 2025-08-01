namespace DocumentinAPI.Domain.DTOs.Folder
{
    public class MoveFolderRequestDTO
    {

        public int FolderId { get; set; }

        public int? ParentFolderId { get; set; }

    }
}
