using FluentValidation.Results;

namespace Domain.Shared.Extensions;

public static class ValidationResultExtensions
{
    public static List<string> MessageErrors(this ValidationResult validationResult)
    {
        var messageErrors = validationResult.Errors
            .Select(e => e.ErrorMessage)
            .ToList();

        return messageErrors;
    }
}