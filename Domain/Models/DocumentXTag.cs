using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.Models
{
    public class DocumentXTag
    {

        [Required]
        public int TagId { get; set; }

        [Required]
        public int DocumentId { get; set; }

    }
}
