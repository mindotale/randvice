using FluentValidation;
using Randvice.Contracts.V1.Advices;

namespace Randvice.Api.Validators.Advices;

public class CreateAdviceRequestValidator : AbstractValidator<CreateAdviceRequest>
{
    public CreateAdviceRequestValidator()
    {
        RuleFor(x => x.Text).NotEmpty().MaximumLength(256);
    }
}
