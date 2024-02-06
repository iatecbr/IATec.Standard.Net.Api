namespace Api.Configurations.Mediator;

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