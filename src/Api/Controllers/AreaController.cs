using System.Net;
using Application.AreaFeatures.Commands;
using Application.AreaFeatures.Queries;
using Application.AreaFeatures.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/area")]
[ApiController]
public class AreaController(ISender mediator) : TemplateBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> SaveArea([FromBody] CreateAreaCommand createAreaCommand)
     {
        var response = await mediator.Send(createAreaCommand);
        return CustomResponse(response, HttpStatusCode.Created);
    }
    
    [HttpPost("add-squad")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> CreateSquad([FromBody] AddSquadToAreaCommand addSquadToAreaCommand)
    {
        var response = await mediator.Send(addSquadToAreaCommand);
        return CustomResponse(response, HttpStatusCode.Created);
    }
    
    [HttpGet("{areaId:int}")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<AreaReadDto>> GetHandlerAreaById([FromRoute] int areaId)
    {
        var areaDto = await mediator.Send(new GetAreaQuery(areaId));
        if (areaDto is null)
            return NotFound();

        return Ok(areaDto);
    }
    
    [HttpGet("get-all-squads")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<AreaSquadReadDto>>> GetAreaSquad()
    {
        var areaSquadList = await mediator.Send(new GetAreaSquadQuery());
        return Ok(areaSquadList);
    }
}