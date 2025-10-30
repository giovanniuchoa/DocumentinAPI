using DocumentinAPI.Domain.DTOs.Document;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Document
{
    public class DocumentDashboardRequestDTOValidator : AbstractValidator<DocumentDashboardRequestDTO>
    {
        public DocumentDashboardRequestDTOValidator()
        {
            RuleFor(x => x.CreatedAtFrom)
                .Must(x => x == null || x.Value != default(DateTime))
                .WithMessage("invalidCreatedAtFromDate");

            RuleFor(x => x.CreatedAtTo)
                .Must(x => x == null || x.Value != default(DateTime))
                .WithMessage("invalidCreatedAtToDate");
        }
    }
}
