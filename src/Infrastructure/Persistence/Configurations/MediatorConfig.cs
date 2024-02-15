using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Configurations;

public static class MediatorConfig
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(MediatorConfig).Assembly);
        });

        return services;
    }
}