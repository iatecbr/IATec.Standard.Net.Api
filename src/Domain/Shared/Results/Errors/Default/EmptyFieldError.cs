using Domain.Shared.Identifies.Contexts;
using Domain.Shared.Messages;
using Domain.Shared.Results.Errors.Base;

namespace Domain.Shared.Results.Errors.Default;

public class EmptyFieldError(string entity, string fieldName, ContextType type)
    : BadRequestFieldsError(DefaultErrorMessageKeys.EmptyFieldMessageKey, type, entity,
        new Dictionary<string, object> { { fieldName, string.Empty } });