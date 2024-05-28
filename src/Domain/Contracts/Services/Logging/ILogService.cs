using Domain.Models.LoggingAggregate.Dtos;

namespace Domain.Contracts.Services.Logging;

public interface ILogService
{
    Task SendAsync(LogDto log, CancellationToken cancellationToken = default);
}