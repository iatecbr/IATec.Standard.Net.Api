using Application.Configurations.Factories;
using Application.Dispatchers.Logging;
using Domain.Contracts.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.Extensions;

public static class ValidatorConfig
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LogDispatcher>();
        services.AddScoped<IValidatorGeneric, ValidatorFactory>();

        return services;
    }
}