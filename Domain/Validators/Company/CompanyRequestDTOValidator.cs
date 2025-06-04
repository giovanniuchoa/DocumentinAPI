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
                .MaximumLength(50).WithMessage("companyNameMaxLength");

            RuleFor(x => x.TaxId)
                .NotEmpty().WithMessage("companyTaxIdRequired")
                .Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$").WithMessage("invalidTaxIdFormat");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("companyPhoneRequired")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("invalidPhoneFormat")
                .MaximumLength(20).WithMessage("companyPhoneMaxLength");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("companyEmailRequired")
                .EmailAddress().WithMessage("invalidEmailFormat");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("companyAddressRequired")
                .MaximumLength(255).WithMessage("companyAddressMaxLength");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("companyZipCodeRequired")
                .Matches(@"^\d{5}-?\d{3}$").WithMessage("invalidZipCodeFormat")
                .MaximumLength(10).WithMessage("companyZipCodeMaxLength");
        }

    }
}
