namespace Domain.Contracts.Dispatcher;

public interface ILogDispatcher
{
    Task DispatchAsync(
        string source,
        string owner,
        string action,
        object? content = null,
        CancellationToken cancellationToken = default
    );
}