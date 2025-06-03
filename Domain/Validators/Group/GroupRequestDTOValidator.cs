using DocumentinAPI.Domain.DTOs.Group;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class GroupRequestDTOValidator : AbstractValidator<GroupRequestDTO>
    {
        public GroupRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("groupNameRequired")
                .MaximumLength(50).WithMessage("groupNameMaxLength");
            
            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("groupDescriptionMaxLength");
        }
    }
}