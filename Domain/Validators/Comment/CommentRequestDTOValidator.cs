using DocumentinAPI.Domain.DTOs.Comment;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.Comment
{
    public class CommentRequestDTOValidator : AbstractValidator<CommentRequestDTO>
    {

        public CommentRequestDTOValidator()
        {
            RuleFor(x => x.CommentId)
                .GreaterThan(0).WithMessage("validCommentIdRequired")
                .When(x => x.CommentId.HasValue);

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("commentContentRequired");

            RuleFor(x => x.DocumentId)
                .GreaterThan(0).WithMessage("validDocumentIdRequired");

        }

    }
}
