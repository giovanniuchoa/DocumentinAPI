using DocumentinAPI.Domain.DTOs.AI;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.AI
{
    public class AIRequestDTOValidator : AbstractValidator<AIRequestDTO>
    {

        public AIRequestDTOValidator()
        {
            RuleFor(x => x.DocumentId)
                .GreaterThan(0).WithMessage("validDocumentIdRequired");

            RuleFor(x => x.Model)
                .Must(model => new[] { 1, 2, 3 }.Contains(model))
                .WithMessage("aiModelOutOfRange");

        }

    }

}
