using FluentResults;
using IATec.Shared.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Base;

public class CustomControllerBase : ControllerBase
{
    [NonAction]
    protected ActionResult CustomResult<T>(Result<T> result, string? location = null)
    {
        if (result.IsCreatedSuccess())
            return Created(location!, result);

        if (result.IsNoContentSuccess() || result.IsEmptyResult())
            return NoContent();

        if (result.IsResourceNotFoundError())
            return NotFound(result);

        if (result.IsBadRequestError() || result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    protected ActionResult CustomResult(Result result, string? location = null)
    {
        if (result.IsCreatedSuccess())
            return Created(location!, result);

        if (result.IsNoContentSuccess())
            return NoContent();

        if (result.IsResourceNotFoundError())
            return NotFound(result);

        if (result.IsBadRequestError() || result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
}