using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class PasswordRecoveryRequestDTOValidator : AbstractValidator<PasswordRecoveryRequestDTO>
    {
        public PasswordRecoveryRequestDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("emailRequired")
                .EmailAddress().WithMessage("invalidEmailFormat");
        }
    }
}