using Domain.Model.AreaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

internal sealed class PersonMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("AreaId")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.FirstName)
            .HasColumnType("nvarchar(150)")
            .IsRequired();
        
        builder.Property(p => p.LastName)
            .HasColumnType("nvarchar(150)")
            .IsRequired();

        builder.Property(p => p.Age)
            .HasColumnType("int");

        builder.ToTable(nameof(Person));
    }
}