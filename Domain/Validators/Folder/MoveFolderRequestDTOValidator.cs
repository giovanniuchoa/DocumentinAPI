using DocumentinAPI.Domain.DTOs.Folder;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Folder
{
    public class MoveFolderRequestDTOValidator : AbstractValidator<MoveFolderRequestDTO>
    {

        public MoveFolderRequestDTOValidator()
        {

            RuleFor(x => x.FolderId)
                .GreaterThan(0).WithMessage("validFolderIdRequired");


            RuleFor(x => x.ParentFolderId)
                .GreaterThan(0).WithMessage("validParentFolderIdRequired")
                .When(x => x.ParentFolderId.HasValue);

        }

    }
}
