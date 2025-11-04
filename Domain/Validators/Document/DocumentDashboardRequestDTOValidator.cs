using DocumentinAPI.Domain.DTOs.Dashboard;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Document
{
    public class DocumentDashboardRequestDTOValidator : AbstractValidator<DashboardRequestDTO>
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
