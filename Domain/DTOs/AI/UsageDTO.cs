using System.Text.Json.Serialization;

namespace DocumentinAPI.Domain.DTOs.AI
{
    public class UsageDTO
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }
    }
}
