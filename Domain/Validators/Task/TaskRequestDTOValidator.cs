using DocumentinAPI.Domain.DTOs.Task;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators
{
    public class TaskRequestDTOValidator : AbstractValidator<TaskRequestDTO>
    {
        public TaskRequestDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("taskTitleRequired")
                .MaximumLength(30).WithMessage("taskTitleMaxLength");
            
            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("taskDescriptionMaxLength");
            
            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("dueDateMustBeFuture");
            
            RuleFor(x => x.Priority)
                .InclusiveBetween((short)1, (short)5).WithMessage("priorityMustBeBetween1And5");
            
            RuleFor(x => x.Status)
                .InclusiveBetween((short)1, (short)4).WithMessage("statusMustBeBetween1And4");
            
            RuleFor(x => x.AssigneeId)
                .GreaterThan(0).WithMessage("validAssigneeIdRequired");
            
            RuleFor(x => x.ParentTaskId)
                .GreaterThan(0).WithMessage("validParentTaskIdRequired")
                .When(x => x.ParentTaskId.HasValue);
        }
    }
}