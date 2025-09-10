using System.Text.Json.Serialization;

namespace DocumentinAPI.Domain.DTOs.AI
{
    public class ChoiceDTO
    {
        [JsonPropertyName("message")]
        public MessageDTO Message { get; set; }
    }
}
