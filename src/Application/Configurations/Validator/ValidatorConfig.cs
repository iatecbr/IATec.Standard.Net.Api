using Application.AreaFeatures.Validators;
using Domain.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.Validator;

public static class ValidatorConfig
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateAreaCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<AreaValidator>();
        services.AddScoped<IValidatorGeneric, ValidatorFactory>();

        return services;
    }
}