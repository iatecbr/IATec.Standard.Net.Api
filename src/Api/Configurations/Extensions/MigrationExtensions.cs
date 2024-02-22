using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Api.Configurations.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var dataContext = scope.ServiceProvider.GetRequiredService<WriteDataContext>();
        dataContext.Database.Migrate();
    }
}