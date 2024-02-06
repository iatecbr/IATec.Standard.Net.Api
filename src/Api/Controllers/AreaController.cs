using System.Net;
using Api.Area.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/area")]
[ApiController]
public class AreaController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> SaveArea([FromBody] CreateAreaCommand createAreaCommand)
    {
        var areaId = await mediator.Send(createAreaCommand);
        return Created(string.Empty, areaId);
    }
}