using FluentValidation;

namespace Domain.Validator;

public interface IValidatorGeneric
{
    IValidator<T>? GetValidator<T>();
}