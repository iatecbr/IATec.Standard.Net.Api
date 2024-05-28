using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Configurations.Filters;

/// <summary>
/// Exception Filter
/// </summary>
public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    /// <summary>
    /// Filter constructor
    /// </summary>
    /// <param name="logger"></param>
    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// On Exception
    /// </summary>
    /// <param name="context"></param>
    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unhandled exception has occurred");

        context.Result = new ObjectResult(new
        {
            IsSuccess = false,
            Reasons = new List<object>
            {
                new
                {
                    Message = "An unhandled exception has occurred",
                    Metadata = context.Exception.InnerException != null
                        ? context.Exception.InnerException.Message
                        : context.Exception.Message
                }
            }
        })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}