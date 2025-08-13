using DocumentinAPI.Domain.DTOs.Template;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Template
{
    public class TemplateRequestDTOValidator : AbstractValidator<TemplateRequestDTO>
    {

        public TemplateRequestDTOValidator()
        {
            RuleFor(x => x.TemplateId)
                .GreaterThan(0).WithMessage("validTemplateIdRequired")
                .When(x => x.TemplateId.HasValue);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("templateNameRequired")
                .MaximumLength(30).WithMessage("templateNameMaxLength");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("contentRequired");

        }

    }
}
