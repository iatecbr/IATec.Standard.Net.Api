using Domain.Contracts.Repositories.Generic;
using Infrastructure.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Configurations;

public static class DatabaseConfig
{
    public static void AddData(this IServiceCollection services, IConfiguration configuration)
    {
        
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<WriteDataContext>((_, options) => options
            .UseSqlServer(connectionString));
        
        var readConnectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<ReadDataContext>((_, options) => options
            .UseSqlServer(readConnectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution));
        
        services.AddScoped<IGenericRepositoryQuery, GenericRepositoryQuery>();
    }
}