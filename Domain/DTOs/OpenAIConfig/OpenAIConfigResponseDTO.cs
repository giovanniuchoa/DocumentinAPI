using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.DTOs.OpenAIConfig
{
    public class OpenAIConfigResponseDTO
    {

        public int OpenAIConfigId { get; set; }
        public int CompanyId { get; set; }
        public string ApiKey { get; set; }


    }
}
