using CrossCutting.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.Extensions;

public static class MediatorConfig
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(MediatorConfig).Assembly);
            config.AddOpenBehavior(typeof(ValidatorPipelineBehavior<,>));
        });

        return services;
    }
}