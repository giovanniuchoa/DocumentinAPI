using DocumentinAPI.Domain.DTOs.FolderXGroup;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.FolderXGroup
{
    public class FolderXGroupRequestDTOValidator : AbstractValidator<FolderXGroupRequestDTO>
    {

        public FolderXGroupRequestDTOValidator()
        {

            RuleFor(x => x.FolderId)
                .GreaterThan(0).WithMessage("validFolderIdRequired");

            RuleFor(x => x.GroupId)
                .GreaterThan(0).WithMessage("validGroupIdRequired");

        }

    }
}
