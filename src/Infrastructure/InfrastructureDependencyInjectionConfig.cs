using Domain.Contracts.Repositories;
using Infrastructure.Persistence.Configurations;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDependencyInjectionConfig
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediator()
            .AddData(configuration);
        
        services.AddScoped<IAreaWriteRepository, AreaWriteRepository>();
        services.AddScoped<IAreaReadRepository, AreaReadRepository>();
    }
}