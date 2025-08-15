using DocumentinAPI.Domain.DTOs.Tag;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Tag
{
    public class DocumentXTagRequestDTOValidator : AbstractValidator<DocumentXTagRequestDTO>
    {

        public DocumentXTagRequestDTOValidator()
        {

            RuleFor(x => x.TagId)
                .GreaterThan(0)
                .WithMessage("validTagIdRequired");

            RuleFor(x => x.DocumentId)
                .GreaterThan(0)
                .WithMessage("validDocumentIdRequired");

        }

    }
}
