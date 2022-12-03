using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Randvice.Api.Controllers.V1.Common;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{

}
