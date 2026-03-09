using DS.Application;
using DS.Contracts;
using DS.Presenters.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DS.Presenters;


[ApiController]
[Route("api/locations")]

public class LocationController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateLocationHandler handler,
        [FromBody] CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var rslt = await handler.Handle(request, cancellationToken);
        if(rslt.IsFailure)
            return BadRequest(Envelope<Guid>.FromErrors(rslt.Error));
        
        return Ok(Envelope<Guid>.Ok(rslt.Value));
    }
}