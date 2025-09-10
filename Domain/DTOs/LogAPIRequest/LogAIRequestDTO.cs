namespace DocumentinAPI.Domain.DTOs.LogAPIRequest
{
    public class LogAIRequestDTO
    {

        public string RequestJson { get; set; }
        public string ResponseJson { get; set; }
        public int RequestTokens { get; set; }
        public int ResponseTokens { get; set; }

    }
}
