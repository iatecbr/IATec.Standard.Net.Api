using Domain.Shared.Messages;
using FluentResults;

namespace Domain.Shared.Results.Successes.Default;

public class CreatedSuccess : Success
{
    public CreatedSuccess(int resourceId)
    {
        Metadata.Add("id", resourceId);
        Message = StatusCodeMessageKeys.CreatedMessageKey;
    }
}