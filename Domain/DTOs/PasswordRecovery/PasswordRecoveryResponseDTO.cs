namespace DocumentinAPI.Domain.DTOs.PasswordRecovery
{
    public class PasswordRecoveryResponseDTO
    {

        public int PasswordRecoveryId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

    }
}
