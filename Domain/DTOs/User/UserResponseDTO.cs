using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DocumentinAPI.Domain.DTOs.Group;

namespace DocumentinAPI.Domain.DTOs.User
{
    public class UserResponseDTO
    {

        public int? UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public short Profile { get; set; }

        public short PreferredLanguage { get; set; }

        public short PreferredTheme { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime LastLoginAt { get; set; }

        public int CompanyId { get; set; }

        public bool IsActive { get; set; }

    }
}
