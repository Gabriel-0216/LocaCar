using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings;

public class RentMap : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.ToTable("Rent");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.ClientId)
            .HasColumnName("ClientId")
            .HasColumnType("INT")
            .IsRequired();

        builder.HasOne(p => p.Client)
            .WithMany(p => p.Rents);

        builder.Property(p => p.PaymentId)
            .HasColumnName("PaymentId")
            .HasColumnType("INT")
            .IsRequired();

        builder.Property(p => p.IsFinished)
            .IsRequired()
            .HasColumnName("IsFinished")
            .HasColumnType("BIt");

        builder.Property(p => p.RentStartDate)
            .IsRequired()
            .HasColumnName("RentStartDate")
            .HasColumnType("DATETIME");
        
        builder.Property(p => p.DevolutionExpectedAt)
            .IsRequired()
            .HasColumnName("DevolutionExpectedAt")
            .HasColumnType("DATETIME");
        
        builder.Property(p => p.DevolutionDate)
            .IsRequired()
            .HasColumnName("DevolutionDate")
            .HasColumnType("DATETIME");

        builder.Property(p => p.RentDate)
            .IsRequired()
            .HasColumnName("RentDate")
            .HasColumnType("DATETIME");

        builder
            .HasOne(p => p.Payment);

        builder.HasMany(p => p.Vehicles)
            .WithMany(p => p.Rents)
            .UsingEntity<Dictionary<string, object>>("VehicleRent",
                vehicle => vehicle
                    .HasOne<Vehicle>()
                    .WithMany()
                    .HasForeignKey("VehicleId")
                    .HasConstraintName("FK_VehicleRent_VehicleId")
                    .OnDelete(DeleteBehavior.NoAction),
                rent => rent
                    .HasOne<Rent>()
                    .WithMany()
                    .HasForeignKey("RentId")
                    .HasConstraintName("FK_VehicleRent_RentId")
                    .OnDelete(DeleteBehavior.NoAction));
        
        builder.Ignore(p => p.Notifications);

        
    }
}