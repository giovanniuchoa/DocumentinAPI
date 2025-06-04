using DocumentinAPI.Domain.DTOs.User;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class UserRequestDTOValidator : AbstractValidator<UserRequestDTO>
    {
        public UserRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("userNameRequired")
                .MaximumLength(20).WithMessage("userNameMaxLength");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("userEmailRequired")
                .EmailAddress().WithMessage("invalidEmailFormat");
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("userPasswordRequired")
                .MinimumLength(6).WithMessage("passwordMinLength")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)").WithMessage("passwordComplexityRequired");
            
            RuleFor(x => x.Profile)
                .InclusiveBetween((short)1, (short)3).WithMessage("profileMustBeBetween1And3");
            
            RuleFor(x => x.PreferredLanguage)
                .InclusiveBetween((short)1, (short)2).WithMessage("preferredLanguageMustBeBetween1And2");
            
            RuleFor(x => x.PreferredTheme)
                .InclusiveBetween((short)1, (short)2).WithMessage("preferredThemeMustBeBetween1And2");
        }
    }
}