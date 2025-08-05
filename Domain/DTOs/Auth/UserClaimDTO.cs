namespace DocumentinAPI.Domain.DTOs.Auth
{
    public class UserClaimDTO
    {

        public int UserId { get; set; }

        public string Name { get; set; }

        public int Profile { get; set; }

        public int CompanyId { get; set; }

        public List<int> GroupsIdsList { get; set; }

        public List<int> FoldersIdsList { get; set; }

    }
}
