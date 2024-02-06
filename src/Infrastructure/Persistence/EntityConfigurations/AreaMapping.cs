using Domain.Model.AreaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

internal sealed class AreaMapping : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("AreaId")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnType("nvarchar(150)")
            .IsRequired();

        builder.Property(p => p.Manager)
            .HasColumnType("nvarchar(255)")
            .IsRequired();

        builder.ToTable(nameof(Area));
    }
}