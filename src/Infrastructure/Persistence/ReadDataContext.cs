using Domain.Model.AreaAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ReadDataContext : DbContext
{
    public DbSet<Area> Area { get; set; }
    public DbSet<Squad> Squad { get; set; }
    public DbSet<Person> Person { get; set; }
    
    public ReadDataContext(DbContextOptions<ReadDataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadDataContext).Assembly);
    }
}