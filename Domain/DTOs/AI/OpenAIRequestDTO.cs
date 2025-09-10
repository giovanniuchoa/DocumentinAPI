namespace DocumentinAPI.Domain.DTOs.AI
{
    public class OpenAIRequestDTO
    {

        public string Model { get; set; }
        public ChatMessageDTO[] Messages { get; set; }

    }
}
