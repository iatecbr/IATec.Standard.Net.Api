using Api.Configurations.Notifier;
using Domain.Contracts.Notifier;

namespace Api.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddScoped<INotifierMessage, NotifierMessage>();

        return services;
    }
}