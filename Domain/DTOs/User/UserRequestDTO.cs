using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.User
{
    public class UserRequestDTO
    {

        public int? UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public short Profile { get; set; }

        public short PreferredLanguage { get; set; }

        public short PreferredTheme { get; set; }

    }
}
