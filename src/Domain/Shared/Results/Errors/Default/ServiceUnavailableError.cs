using Domain.Shared.Messages;
using FluentResults;

namespace Domain.Shared.Results.Errors.Default;

public class ServiceUnavailableError : Error
{
    public ServiceUnavailableError()
    {
        Message = DefaultErrorMessageKeys.ServiceUnavailableMessageKey;
    }
}