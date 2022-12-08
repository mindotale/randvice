using Microsoft.AspNetCore.Mvc.Filters;

namespace Randvice.Api.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        if(!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(x => x.ErrorMessage).ToArray());

            throw new NotImplementedException();
        }
        await next();
    }
}
