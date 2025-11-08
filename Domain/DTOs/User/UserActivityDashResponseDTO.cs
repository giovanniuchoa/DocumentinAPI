namespace DocumentinAPI.Domain.DTOs.User
{
    public class UserActivityDashResponseDTO
    {

        public string Username { get; set; }
        public int Modifications { get; set; }
        public int Comments { get; set; }
        public int Approvals { get; set; }

    }
}
