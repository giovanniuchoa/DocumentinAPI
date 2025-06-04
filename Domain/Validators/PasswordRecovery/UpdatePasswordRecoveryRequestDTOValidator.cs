using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class UpdatePasswordRecoveryRequestDTOValidator : AbstractValidator<UpdatePasswordRecoveryRequestDTO>
    {
        public UpdatePasswordRecoveryRequestDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("emailRequired")
                .EmailAddress().WithMessage("invalidEmailFormat");
            
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("tokenRequired");
            
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("newPasswordRequired")
                .MinimumLength(6).WithMessage("passwordMinLength")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)").WithMessage("passwordComplexityRequired");
        }
    }
}