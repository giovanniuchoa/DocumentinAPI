using DocumentinAPI.Domain.DTOs.DocumentVersion;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class DocumentVersionAddCommentRequestDTOValidator : AbstractValidator<DocumentVersionAddCommentRequestDTO>
    {
        public DocumentVersionAddCommentRequestDTOValidator()
        {
            RuleFor(x => x.DocumentVersionId)
                .GreaterThan(0).WithMessage("validDocumentVersionIdRequired");
            
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("commentRequired")
                .MaximumLength(500).WithMessage("commentMaxLength");
        }
    }
}