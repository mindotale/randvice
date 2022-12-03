using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Randvice.Api.Controllers.V1.Common;
using Randvice.Contracts.V1.Advices;
using Randvice.Contracts.V1.Common;

namespace Randvice.Api.Controllers.V1;

[AllowAnonymous]
public class AdvicesController : ApiController
{
    [HttpGet("{id:guid}")]
    public Task<IActionResult> Get(Guid id)
    {

    }

    [HttpGet("random")]
    public Task<IActionResult> Get()
    {

    }

    [HttpGet]
    public Task<IActionResult> Get([FromQuery] PaginationRequestQuery paginationRequest)
    {

    }

    [HttpPost]
    public Task<IActionResult> Create([FromBody] CreateAdviceRequest request)
    {

    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> Update(Guid id, [FromBody] UpdateAdviceRequest request)
    {

    }

    [HttpDelete]
    public Task<IActionResult> Delete(Guid id)
    {

    }
}
