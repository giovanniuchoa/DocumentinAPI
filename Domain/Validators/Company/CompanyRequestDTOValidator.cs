using DocumentinAPI.Domain.DTOs.Company;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class CompanyRequestDTOValidator : AbstractValidator<CompanyRequestDTO>
    {

        public CompanyRequestDTOValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("companyNameRequired")
                .MaximumLength(15).WithMessage("companyNameMaxLength");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("companyEmailRequired")
                .EmailAddress().WithMessage("invalidEmailFormat");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("companyPhoneRequired")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("invalidPhoneFormat");
        }

    }
}
