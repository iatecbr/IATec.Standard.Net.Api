using FluentResults;
using IATec.Shared.Domain.Messages;

namespace Domain.Shared.Results.Errors.Default;

public class ServiceUnavailableError : Error
{
    public ServiceUnavailableError()
    {
        Message = DefaultErrorMessageKeys.ServiceUnavailableMessageKey;
    }
}