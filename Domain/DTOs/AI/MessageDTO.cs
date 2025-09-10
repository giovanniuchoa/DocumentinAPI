using System.Text.Json.Serialization;

namespace DocumentinAPI.Domain.DTOs.AI
{
    public class MessageDTO
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
