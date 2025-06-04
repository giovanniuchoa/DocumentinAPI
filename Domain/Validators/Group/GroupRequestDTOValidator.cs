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
                .MaximumLength(20).WithMessage("groupNameMaxLength");
            
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("groupDescriptionRequired")
                .MaximumLength(255).WithMessage("groupDescriptionMaxLength");
        }
    }
}