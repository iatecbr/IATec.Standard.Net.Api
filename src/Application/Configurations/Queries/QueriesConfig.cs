using Application.AreaFeatures.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.Queries;

public static class QueriesConfig
{
    public static void AddQueries(this IServiceCollection services)
    {
        services.AddScoped<IAreaQueries, AreaQueries>();
    }
}