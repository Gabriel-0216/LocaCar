using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings;

public class FuelTypeMap : IEntityTypeConfiguration<FuelType>
{
    public void Configure(EntityTypeBuilder<FuelType> builder)
    {
        builder.ToTable("FuelType");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(p => p.Vehicles)
            .WithOne(p => p.FuelType)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Ignore(p => p.Notifications);
    }
}