using Application.Configurations.Factories;
using IATec.Shared.Domain.Contracts.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.Extensions;

public static class ValidatorConfig
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        //services.AddValidatorsFromAssemblyContaining<CreateAssetCommandValidator>();
        services.AddScoped<IValidatorGeneric, ValidatorFactory>();

        return services;
    }
}