namespace DocumentinAPI.Domain.DTOs.DocumentValidation
{
    public class DocumentValidationDashResponseDTO
    {

        public int TotalValidations { get; set; }
        public int TotalApproved { get; set; }
        public int TotalRejected { get; set; }
        public int TotalInRevision { get; set; }

    }
}
