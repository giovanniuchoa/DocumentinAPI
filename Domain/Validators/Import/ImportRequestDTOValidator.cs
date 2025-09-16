using DocumentinAPI.Domain.DTOs.Import;
using DocumentinAPI.Domain.DTOs.Supabase;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Import
{
    public class ImportRequestDTOValidator : AbstractValidator<ImportRequestDTO>
    {

        public ImportRequestDTOValidator()
        {
            RuleFor(x => x.File)
                .NotNull().WithMessage("fileRequired")
                .Must(BeValidFile).WithMessage("invalidFileFormat");

            RuleFor(x => x.FolderId)
                .GreaterThan(0).WithMessage("validFolderIdRequired");

        }

        private bool BeValidFile(IFormFile file)
        {
            if (file == null) return false;

            var allowedExtensions = new[] { ".pdf", ".docx" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            return allowedExtensions.Contains(fileExtension);
        }

    }
}
