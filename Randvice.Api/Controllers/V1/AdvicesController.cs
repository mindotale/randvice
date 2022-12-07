using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Randvice.Api.Controllers.V1.Common;
using Randvice.Contracts.V1.Advices;
using Randvice.Contracts.V1.Common;
using Randvice.Contracts.V1.Identity;
using Randvice.Core.Advices;
using Randvice.Core.Common.Models;

namespace Randvice.Api.Controllers.V1;

public class AdvicesController : ApiController
{
    private readonly IAdviceService _adviceService;

    public AdvicesController(IAdviceService adviceService, IMapper mapper) : base(mapper)
    {
        _adviceService = adviceService;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AdviceResponse), 200)]
    public async Task<ActionResult<AdviceResponse>> Get(Guid id)
    {
        var advice = await _adviceService.GetAdviceByIdAsync(id);
        var response = Mapper.Map<AdviceResponse>(advice);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("random")]
    [ProducesResponseType(typeof(AdviceResponse), 200)]
    public async Task<ActionResult<AdviceResponse>> GetRandom()
    {
        var advice = await _adviceService.GetRandomAdviceAsync();
        var response = Mapper.Map<AdviceResponse>(advice);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedList<AdviceResponse>), 200)]
    public async Task<ActionResult<PagedList<AdviceResponse>>> GetPaginated(
        [FromQuery] PaginationRequestQuery paginationRequest)
    {
        var paginatioFilter = Mapper.Map<PaginationFilter>(paginationRequest);
        var advices = await _adviceService.GetAdvicesWithPaginationAsync(paginatioFilter);
        var response = Mapper.Map<PagedList<AdviceResponse>>(advices);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AdviceResponse), 201)]
    public async Task<ActionResult<AdviceResponse>> Create([FromBody] CreateAdviceRequest request)
    {
        var command = Mapper.Map<CreateAdviceCommand>(request);
        var advice = await _adviceService.CreateAdviceAsync(command);
        var response = Mapper.Map<AdviceResponse>(advice);
        return Created($"api/advices/{response.Id}",response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(AdviceResponse), 200)]
    public async Task<ActionResult<AdviceResponse>> Update(
        Guid id,
        [FromBody] UpdateAdviceRequest request)
    {
        var command = Mapper.Map<UpdateAdviceCommand>((id,request));
        var advice = await _adviceService.UpdateAdviceAsync(command);
        var response = Mapper.Map<AdviceResponse>(advice);
        return Ok(response);
    }

    [HttpDelete]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _adviceService.DeleteAdviceAsync(id);
        return NoContent();
    }
}
