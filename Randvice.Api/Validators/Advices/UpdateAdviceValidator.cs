using FluentValidation;
using Randvice.Contracts.V1.Advices;

namespace Randvice.Api.Validators.Advices;

public class UpdateAdviceRequestValidator : AbstractValidator<UpdateAdviceRequest>
{
    public UpdateAdviceRequestValidator()
    {
        RuleFor(x => x.Text).NotEmpty().MaximumLength(256);
    }
}
