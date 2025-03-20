using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class Group
    {

        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
