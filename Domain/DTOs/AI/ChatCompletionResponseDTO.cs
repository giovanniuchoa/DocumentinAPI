using System.Text.Json.Serialization;

namespace DocumentinAPI.Domain.DTOs.AI
{
    public class ChatCompletionResponseDTO
    {
        [JsonPropertyName("choices")]
        public ChoiceDTO[] Choices { get; set; }

        [JsonPropertyName("usage")]
        public UsageDTO Usage { get; set; }
    }
}
