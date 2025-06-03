using DocumentinAPI.Domain.DTOs.UserXGroup;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class UserXGroupRequestDTOValidator : AbstractValidator<UserXGroupRequestDTO>
    {
        public UserXGroupRequestDTOValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("validUserIdRequired");
            
            RuleFor(x => x.GroupId)
                .GreaterThan(0).WithMessage("validGroupIdRequired");
        }
    }
}