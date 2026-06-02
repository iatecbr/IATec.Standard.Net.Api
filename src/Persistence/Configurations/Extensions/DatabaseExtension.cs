using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Persistence.Configurations.Options;

namespace Persistence.Configurations.Extensions;

public static class DatabaseExtension
{
    public static void AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection(MongoOption.Key).Get<MongoOption>();

        var pack = new ConventionPack
        {
            //CamelCase is default name convention for performance and readability
            new CamelCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true)
        };

        ConventionRegistry.Register("MyMongoConventions", pack, _ => true);

        services.AddSingleton<IMongoClient>(_ => new MongoClient(options!.GetConnectionString()));

        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(options!.Database);
        });
    }
}