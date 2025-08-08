using DocumentinAPI.Domain.DTOs.DocumentValidation;
using DocumentinAPI.Domain.Utils;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.DocumentValidation
{
    public class DocumentValidationRequestDTOValidator : AbstractValidator<DocumentValidationRequestDTO>
    {

        public DocumentValidationRequestDTOValidator()
        {

            RuleFor(x => x.DocumentId)
                .GreaterThan(0).WithMessage("validDocumentIdRequired");

            RuleFor(x => x.Status)
                .Must(s => s == (short)Enums.StatusValidacao.EmAndamento || s == (short)Enums.StatusValidacao.Validado || s == (short)Enums.StatusValidacao.Retornado)
                .WithMessage("validStatusRequired");
        }

    }
}
