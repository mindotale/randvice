using Randvice.Contracts.V1.Advices;
using Swashbuckle.AspNetCore.Filters;

namespace Randvice.Api.Swagger.Examples.Advices;

public class CreateAdviceRequestExample : IExamplesProvider<CreateAdviceRequest>
{
    public CreateAdviceRequest GetExamples()
    {
        return new CreateAdviceRequest("Tell it like it is.");
    }
}
