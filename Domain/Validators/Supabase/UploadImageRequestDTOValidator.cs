using DocumentinAPI.Domain.DTOs.Supabase;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Supabase
{
    public class UploadImageRequestDTOValidator : AbstractValidator<UploadImageRequestDTO>
    {

        public UploadImageRequestDTOValidator()
        {
            RuleFor(x => x.Image)
                .NotNull().WithMessage("imageRequired");

        }

    }
}
