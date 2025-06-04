using DocumentinAPI.Domain.DTOs.DocumentVersion;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class DocumentVersionRequestDTOValidator : AbstractValidator<DocumentVersionRequestDTO>
    {
        public DocumentVersionRequestDTOValidator()
        {
            RuleFor(x => x.DocumentId)
                .GreaterThan(0).WithMessage("validDocumentIdRequired");
            
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("documentContentRequired");
            
            RuleFor(x => x.Comment)
                .MaximumLength(255).WithMessage("commentMaxLength");
        }
    }
}