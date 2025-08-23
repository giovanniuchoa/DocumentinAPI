using Supabase.Gotrue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class OpenAIConfig
    {

        [Key]
        public int OpenAIConfigId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string ApiKey { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }

    }
}
