using Domain.Contracts.Repositories;
using Domain.SeedWorks;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Configurations;

public static class DatabaseConfig
{
    public static void AddData(this IServiceCollection services, IConfiguration configuration)
    {
        
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<DataContext>((_, options) => options
            .UseSqlServer(connectionString));
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<DataContext>());

        services.AddScoped<IAreaRepository, AreaRepository>();
    }
}