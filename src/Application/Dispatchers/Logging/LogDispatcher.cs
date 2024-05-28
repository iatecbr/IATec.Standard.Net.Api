using Domain.Contracts.Dispatcher;
using Domain.Contracts.Services.Logging;
using Domain.Models.LoggingAggregate.Dtos;
using Domain.Shared.Options;
using Microsoft.Extensions.Options;

namespace Application.Dispatchers.Logging;

public class LogDispatcher(ILogService logService, IOptions<ContainerOption> options) : ILogDispatcher
{
    public async Task DispatchAsync(
        string source,
        string owner,
        string action,
        object? content = null,
        CancellationToken cancellationToken = default
    )
    {
        await logService.SendAsync(new LogDto(
            options.Value.Name,
            source,
            owner,
            action,
            "-",
            content
        ), cancellationToken);
    }
}