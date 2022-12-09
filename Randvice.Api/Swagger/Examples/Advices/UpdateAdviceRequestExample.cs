using Randvice.Contracts.V1.Advices;
using Swashbuckle.AspNetCore.Filters;

namespace Randvice.Api.Swagger.Examples.Advices;

public class UpdateAdviceRequestExample : IExamplesProvider<UpdateAdviceRequest>
{
    public UpdateAdviceRequest GetExamples()
    {
        return new UpdateAdviceRequest("Tell it like it is.");
    }
}
