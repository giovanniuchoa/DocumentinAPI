using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class ValidatePasswordRecoveryRequestDTOValidator : AbstractValidator<ValidatePasswordRecoveryRequestDTO>
    {
        public ValidatePasswordRecoveryRequestDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("emailRequired")
                .EmailAddress().WithMessage("invalidEmailFormat");
            
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("tokenRequired");
        }
    }
}