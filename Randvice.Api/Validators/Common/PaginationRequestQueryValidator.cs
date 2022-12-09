using FluentValidation;
using Randvice.Contracts.V1.Common;

namespace Randvice.Api.Validators.Advices;

public class PaginationRequestQueryValidator : AbstractValidator<PaginationRequestQuery>
{
    public PaginationRequestQueryValidator()
    {
        RuleFor(x => x.PageNumber).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageNumber).NotEmpty().GreaterThanOrEqualTo(0);
    }
}
