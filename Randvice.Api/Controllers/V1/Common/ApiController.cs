using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Randvice.Api.Controllers.V1.Common;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected IMapper Mapper { get; }

    protected ApiController(IMapper mapper)
    {
        Mapper = mapper;
    }
}
