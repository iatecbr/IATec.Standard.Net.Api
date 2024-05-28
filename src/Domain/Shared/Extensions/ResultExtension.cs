using Domain.Shared.Messages;
using Domain.Shared.Results.Errors.Base;
using Domain.Shared.Results.Errors.Default;
using Domain.Shared.Results.Successes.Default;
using FluentResults;

namespace Domain.Shared.Extensions;

/// <summary>
/// Extension for FluentResult
/// </summary>
public static class ResultExtension
{
    public static bool IsCreatedSuccess(this ResultBase result)
    {
        return result.HasSuccess<CreatedSuccess>();
    }

    public static bool IsNoContentSuccess(this ResultBase result)
    {
        return result.HasSuccess<NoContentSuccess>();
    }

    public static bool IsEmptyResult<T>(this Result<T> result)
    {
        return result.IsSuccess
               && (result.Value is null
                   || result.HasSuccess(x => x.Message.Equals(StatusCodeMessageKeys.NoContentMessageKey)));
    }

    public static bool IsResourceNotFoundError(this ResultBase result)
    {
        return result.HasError<ResourceNotFoundError>();
    }

    public static bool IsBadRequestError(this ResultBase result)
    {
        return result.HasError<BadRequestFieldsError>();
    }
}