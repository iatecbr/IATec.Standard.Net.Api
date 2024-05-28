using Domain.Shared.Identifies.Contexts;
using FluentResults;

namespace Domain.Shared.Results.Errors.Base;

public class BadRequestFieldsError : Error
{
    protected BadRequestFieldsError(string messageKey, ContextType type, string entityName,
        Dictionary<string, object>? valueParams = null)
    {
        valueParams = TransformKeys(valueParams, type, entityName);
        Message = messageKey;
        Metadata.Add("entityName", $"api.{type.Value}.entity.{entityName}.entity-name".ToLower());
        Metadata.Add("valueParams", valueParams);
    }

    private static Dictionary<string, object> TransformKeys(Dictionary<string, object>? valueParams, ContextType type,
        string entityName)
    {
        Dictionary<string, object> result = new();

        if (valueParams is null) return result;

        foreach (var item in valueParams)
            result.Add($"api.{type.Value}.entity.{entityName}.field.{item.Key}".ToLower(), item.Value);

        return result;
    }
}