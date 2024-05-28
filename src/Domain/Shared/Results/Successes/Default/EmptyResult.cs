using Domain.Shared.Messages;
using FluentResults;

namespace Domain.Shared.Results.Successes.Default;

public class EmptyResult : Result
{
    public static Result GetResult()
    {
        return Ok().WithSuccess(StatusCodeMessageKeys.NoContentMessageKey);
    }
}