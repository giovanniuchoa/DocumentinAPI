using DocumentinAPI.Domain.DTOs.Folder;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Folder
{
    public class FolderRequestDTOValidator : AbstractValidator<FolderRequestDTO>
    {

        public FolderRequestDTOValidator()
        {

            RuleFor(x => x.FolderId)
                .GreaterThan(0).WithMessage("validFolderIdRequired")
                .When(x => x.FolderId.HasValue);

            RuleFor(x => x.Name)
                .MaximumLength(20).WithMessage("folderNameMaxLength");

            RuleFor(x => x.ParentFolderId)
                .GreaterThan(0).WithMessage("validParentFolderIdRequired")
                .When(x => x.ParentFolderId.HasValue);

            RuleFor(x => x.ValidatorId)
                .GreaterThan(0).WithMessage("validValidatorIdRequired");

        }

    }
}
