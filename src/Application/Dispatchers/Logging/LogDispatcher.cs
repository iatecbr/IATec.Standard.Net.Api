using IATec.Shared.Domain.Contracts.Dispatcher;
using IATec.Shared.Domain.Contracts.Services.Logging;
using IATec.Shared.Domain.Models.LoggingAggregate.Dtos;
using IATec.Shared.Domain.Options;
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