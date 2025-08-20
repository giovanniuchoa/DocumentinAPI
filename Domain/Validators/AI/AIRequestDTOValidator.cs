using DocumentinAPI.Domain.DTOs.AI;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.AI
{
    public class AIRequestDTOValidator : AbstractValidator<AIRequestDTO>
    {

        public AIRequestDTOValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("validContentRequired");
        }

    }

}
