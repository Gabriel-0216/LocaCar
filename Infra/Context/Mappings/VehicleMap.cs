using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings;

public class VehicleMap : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Brand)
            .HasColumnName("Brand")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Model)
            .HasColumnName("Model")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Year)
            .HasColumnName("Year")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(p => p.CategoryId)
            .HasColumnName("CategoryId")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FuelTypeId)
            .HasColumnName("FuelTypeId")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.ImageUrl)
            .HasColumnName("ImageUrl")
            .HasColumnType("nvarchar")
            .IsRequired();

        builder.Property(p => p.CreateDate)
            .HasColumnName("CreateDate")
            .HasColumnType("DATETIME")
            .IsRequired();
        
        builder.Property(p => p.UpdateDate)
            .HasColumnName("UpdateDate")
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(p => p.IsAvailable)
            .HasColumnName("IsAvailable")
            .HasColumnType("BIT")
            .IsRequired();

        builder.HasOne(p => p.Category)
            .WithMany(p => p.Vehicles)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.FuelType)
            .WithMany(p => p.Vehicles)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasMany(p => p.Rents)
            .WithMany(p => p.Vehicles)
            .UsingEntity<Dictionary<string, object>>("VehicleRent",
                rent => rent
                    .HasOne<Rent>()
                    .WithMany()
                    .HasForeignKey("RentId")
                    .HasConstraintName("FK_VehicleRent_RentId")
                    .OnDelete(DeleteBehavior.NoAction),
                vehicle => vehicle
                    .HasOne<Vehicle>()
                    .WithMany()
                    .HasForeignKey("VehicleId")
                    .HasConstraintName("FK_VehicleRent_VehicleId")
                    .OnDelete(DeleteBehavior.NoAction));
        
        

        


        builder.Ignore(p => p.Notifications);



    }
}