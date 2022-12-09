using Randvice.Contracts.V1.Advices;
using Randvice.Contracts.V1.Common;
using Swashbuckle.AspNetCore.Filters;

namespace Randvice.Api.Swagger.Examples.Common;

public class PagedListOfAdviceResponsesExample : IExamplesProvider<PagedList<AdviceResponse>>
{
    public PagedList<AdviceResponse> GetExamples()
    {
        return new PagedList<AdviceResponse>
        {
            PageCount = 4,
            TotalItemCount = 17,
            PageNumber = 2,
            PageSize = 5,
            HasPreviousPage= true,
            HasNextPage= true,
            IsFirstPage = false,
            IsLastPage= false,
            FirstItemOnPage = 6,
            LastItemOnPage = 10,
            Items = new List<AdviceResponse>
            {
                new AdviceResponse(Guid.NewGuid().ToString(), "Tell it like it is."),
                new AdviceResponse(Guid.NewGuid().ToString(), "Tell it like it is."),
                new AdviceResponse(Guid.NewGuid().ToString(), "Tell it like it is."),
                new AdviceResponse(Guid.NewGuid().ToString(), "Tell it like it is."),
                new AdviceResponse(Guid.NewGuid().ToString(), "Tell it like it is.")
            }
        };
    }
}
