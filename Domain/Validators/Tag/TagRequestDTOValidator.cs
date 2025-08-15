using DocumentinAPI.Domain.DTOs.Tag;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Tag
{
    public class TagRequestDTOValidator : AbstractValidator<TagRequestDTO>
    {
        public TagRequestDTOValidator()
        {

            RuleFor(tag => tag.TagId)
                .GreaterThan(0).WithMessage("validTagIdRequired")
                .When(x => x.TagId.HasValue);

            RuleFor(tag => tag.Name)
                .NotEmpty().WithMessage("tagNameRequired")
                .MaximumLength(20).WithMessage("tagNameMaxLength");

        }
    }

}
