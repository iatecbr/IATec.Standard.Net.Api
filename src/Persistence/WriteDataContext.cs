using Domain.Model.AreaAggregate;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class WriteDataContext : DbContext
{
    public DbSet<Area> Area { get; set; }
    public DbSet<Squad> Squad { get; set; }
    public DbSet<Person> Person { get; set; }
    
    public WriteDataContext(DbContextOptions<WriteDataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WriteDataContext).Assembly);
    }
}