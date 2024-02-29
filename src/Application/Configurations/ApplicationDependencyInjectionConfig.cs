using Application.Configurations.Mediator;
using Application.Configurations.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations;

public static class ApplicationDependencyInjectionConfig
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediator()
            .AddValidators();
        
        return services;
    }
}