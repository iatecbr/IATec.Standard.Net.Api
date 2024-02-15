using System.Net;
using Api.DTOs;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class TemplateBaseController : ControllerBase
{
    protected ActionResult CustomResponse<TValue>(Response<TValue> response, HttpStatusCode httpStatusCode)
    {
        if (response.ResponseType is ResponseType.Failure or ResponseType.NotFound)
        {
            var statusCode = response.ResponseType == ResponseType.Failure
                ? (int)HttpStatusCode.BadRequest
                : (int)HttpStatusCode.NotFound;
            
            var resultFail = new CustomResponse(false, statusCode, null, response.Messages, 
                DateTimeOffset.UtcNow);
            
            return statusCode == (int)HttpStatusCode.BadRequest ? BadRequest(resultFail) : NotFound();
        }

        var resultSuccess = new CustomResponse(true, (int)httpStatusCode, response.Value, null, 
            DateTimeOffset.UtcNow);
        
        return httpStatusCode switch
        {
            HttpStatusCode.Created => Created(string.Empty, resultSuccess),
            HttpStatusCode.OK => Ok(resultSuccess),
            _ => Ok(),
        };
    }
}