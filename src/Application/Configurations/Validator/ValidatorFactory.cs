using Domain.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.Validator;

public class ValidatorFactory(IServiceProvider serviceProvider) : IValidatorGeneric
{
    
    public IValidator<T>? GetValidator<T>()
    {
        var validator = serviceProvider.GetService<IValidator<T>>();
        return validator;
    }
}