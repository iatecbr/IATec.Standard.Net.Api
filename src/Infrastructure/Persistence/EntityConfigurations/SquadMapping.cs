using Domain.Model.AreaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

internal sealed class SquadMapping : IEntityTypeConfiguration<Squad>
{
    public void Configure(EntityTypeBuilder<Squad> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("SquadId")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnType("nvarchar(150)")
            .IsRequired();

        builder.Property(p => p.AmountPerson)
            .HasColumnType("int");

        builder.ToTable(nameof(Squad));
    }
}