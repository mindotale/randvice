using Randvice.Contracts.V1.Advices;
using Swashbuckle.AspNetCore.Filters;

namespace Randvice.Api.Swagger.Examples.Advices;

public class AdviceResponseExample : IExamplesProvider<AdviceResponse>
{
    public AdviceResponse GetExamples()
    {
        return new AdviceResponse(Guid.NewGuid().ToString(), "Tell it like it is.");
    }
}
