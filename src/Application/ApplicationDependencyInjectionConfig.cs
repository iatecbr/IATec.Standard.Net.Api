using Application.Configurations.Mediator;
using Application.Configurations.Queries;
using Application.Configurations.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationDependencyInjectionConfig
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediator()
            .AddValidators()
            .AddQueries();
        
        return services;
    }
}