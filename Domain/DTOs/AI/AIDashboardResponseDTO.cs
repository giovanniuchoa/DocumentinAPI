namespace DocumentinAPI.Domain.DTOs.AI
{
    public class AIDashboardResponseDTO
    {

        public int TotalRequests { get; set; }
        public int TotalTokens { get; set; }
        public int RequestAverageTokens { get; set; }
        public decimal EstimatedCost { get; set; }

    }
}
