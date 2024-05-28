using Domain.Shared.Messages;
using FluentResults;

namespace Domain.Shared.Results.Errors.Default;

public class ResourceNotFoundError : Error
{
    public ResourceNotFoundError()
    {
        Message = StatusCodeMessageKeys.NotFoundMessageKey;
    }
}