using Domain.Model.AreaAggregate;
using Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DataContext : DbContext, IUnitOfWork
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    public DbSet<Area> Area { get; set; }
    public DbSet<Squad> Users { get; set; }
    public DbSet<Person> Followers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}