using Domain.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Configurations;

public static class InfrastructureDependencyInjectionConfig
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddData(configuration);
        
        services.AddScoped<IAreaWriteRepository, AreaWriteRepository>();
        services.AddScoped<IAreaReadRepository, AreaReadRepository>();
    }
}