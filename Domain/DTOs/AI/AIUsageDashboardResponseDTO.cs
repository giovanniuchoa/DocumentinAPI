namespace DocumentinAPI.Domain.DTOs.AI
{
    public class AIUsageDashboardResponseDTO
    {

        public string Name { get; set; }
        public int TotalRequests { get; set; }
        public int TotalTokens { get; set; }
        public int TokenAverage { get; set; }
        public int UsePercentage { get; set; }

    }
}
