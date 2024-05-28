using Domain.Shared.Messages;
using FluentResults;

namespace Domain.Shared.Results.Successes.Default;

public class NoContentSuccess : Success
{
    public NoContentSuccess()
    {
        Message = StatusCodeMessageKeys.NoContentMessageKey;
    }
}