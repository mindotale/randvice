using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Randvice.Api.Controllers.V1.Common;
using Randvice.Contracts.V1.Identity;
using Randvice.Core.Identity;

namespace Randvice.Api.Controllers.V1;

[AllowAnonymous]
public class IdentityController : ApiController
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService, IMapper mapper) : base(mapper)
    {
        _identityService = identityService;
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(AuthenticationResponse), 200)]
    public async Task<ActionResult<AuthenticationResponse>> Login(
        [FromBody] LoginUserRequest request)
    {
        var command = Mapper.Map<LoginUserCommand>(request);
        var authenticationCredentials = await _identityService.LoginAsync(command);
        var response = Mapper.Map<AuthenticationResponse>(authenticationCredentials);
        return Ok(response);
    }
}
