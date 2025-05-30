using DocumentinAPI.Domain.DTOs.Auth;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class AuthRequestDTOValidator : AbstractValidator<AuthRequestDTO>
    {

        public AuthRequestDTOValidator()
        {

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("loginRequired")
                .EmailAddress().WithMessage("invalidEmailFormat");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("passwordRequired")
                .MinimumLength(6).WithMessage("passwordLengthSixChar");
        }

    }
}
