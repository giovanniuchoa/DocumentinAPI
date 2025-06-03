using DocumentinAPI.Domain.DTOs.Supabase;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Supabase
{
    public class UploadImageRequestDTOValidator : AbstractValidator<UploadImageRequestDTO>
    {

        public UploadImageRequestDTOValidator()
        {
            RuleFor(x => x.Image)
                .NotNull().WithMessage("imageRequired")
                .Must(BeValidImageFile).WithMessage("invalidImageFormat");

        }

        private bool BeValidImageFile(IFormFile file)
        {
            if (file == null) return false;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            /* Limite 5MB */
            return allowedExtensions.Contains(fileExtension) && file.Length > 0 && file.Length <= 5 * 1024 * 1024; 
        }

    }
}
