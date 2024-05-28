using AntiCorruption.Services.Iatec;
using Domain.Contracts.Services.Logging;
using Domain.Shared.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AntiCorruption.Configurations.Extensions;

public static class LoggingConfig
{
    public static IServiceCollection AddLoggingService(this IServiceCollection services)
    {
        services.AddHttpClient<ILogService, LogService>((serviceProvider, client) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<LogServiceOption>>().Value;

            if (string.IsNullOrWhiteSpace(options.Url))
                throw new ArgumentNullException(nameof(options.Url), "Log service url is required");

            client.BaseAddress = new Uri(options.Url);
        });

        return services;
    }
}