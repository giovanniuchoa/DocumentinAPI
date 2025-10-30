namespace DocumentinAPI.Domain.DTOs.Document
{
    public class DocumentDashboardResponseDTO
    {

        public int TotalDocuments { get; set; }
        public int ActiveDocuments { get; set; }
        public int InactiveDocuments { get; set; }
        public int ApprovedDocuments { get; set; }
        public int PendingDocuments { get; set; }
        public int RejectedDocuments { get; set; }

    }
}
