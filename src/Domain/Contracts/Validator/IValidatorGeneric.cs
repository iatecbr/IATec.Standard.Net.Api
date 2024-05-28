using FluentValidation;

namespace Domain.Contracts.Validator;

public interface IValidatorGeneric
{
    IValidator<T>? GetValidator<T>();
}