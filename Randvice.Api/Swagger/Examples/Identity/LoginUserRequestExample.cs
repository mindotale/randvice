using Randvice.Contracts.V1.Advices;
using Randvice.Contracts.V1.Identity;
using Swashbuckle.AspNetCore.Filters;

namespace Randvice.Api.Swagger.Examples.Advices;

public class LoginUserRequestExample : IExamplesProvider<LoginUserRequest>
{
    public LoginUserRequest GetExamples()
    {
        return new LoginUserRequest("test@mail.com", "1!Password");
    }
}
