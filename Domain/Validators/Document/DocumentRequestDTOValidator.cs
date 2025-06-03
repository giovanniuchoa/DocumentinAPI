using DocumentinAPI.Domain.DTOs.Document;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Document
{
    public class DocumentRequestDTOValidator : AbstractValidator<DocumentRequestDTO>
    {

        public DocumentRequestDTOValidator()
        {

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("documentTitleRequired")
                .MaximumLength(100).WithMessage("documentTitleMaxLength");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("documentContentRequired");

            RuleFor(x => x.FolderId)
                .NotEmpty().WithMessage("folderIdRequired");

        }

    }
}
