using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Group
{
    public class GroupResponseDTO
    {

        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public int CompanyId { get; set; }

        public bool IsActive { get; set; }

    }
}
