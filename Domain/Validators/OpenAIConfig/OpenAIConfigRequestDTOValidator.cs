using DocumentinAPI.Domain.DTOs.OpenAIConfig;
using FluentValidation;

namespace DocumentinAPI.Domain.Validators.OpenAIConfig
{
    public class OpenAIConfigRequestDTOValidator : AbstractValidator<OpenAIConfigRequestDTO>
    {

        public OpenAIConfigRequestDTOValidator()
        {
            RuleFor(x => x.ApiKey)
                .NotEmpty().WithMessage("validApiKeyRequired");
        }

    }
}
