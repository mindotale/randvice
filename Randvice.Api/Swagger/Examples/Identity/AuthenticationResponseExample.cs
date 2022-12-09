using Randvice.Contracts.V1.Identity;
using Swashbuckle.AspNetCore.Filters;

namespace Randvice.Api.Swagger.Examples.Identity;

public class AuthenticationResponseExample : IExamplesProvider<AuthenticationResponse>
{
    public AuthenticationResponse GetExamples()
    {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        return new AuthenticationResponse(token);
    }
}
