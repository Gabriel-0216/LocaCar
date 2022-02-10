using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings;

public class PaymentMap : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.ClientId)
            .HasColumnName("ClientId")
            .HasColumnType("INT")
            .IsRequired();

        builder.Property(p => p.PaymentTypeId)
            .HasColumnName("PaymentTypeId")
            .HasColumnType("INT")
            .IsRequired();

        builder.Property(p => p.PaymentDate)
            .HasColumnName("PaymentDate")
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(p => p.Value)
            .HasColumnName("Value")
            .HasColumnType("decimal")
            .IsRequired();

        builder.HasOne(p => p.Client)
            .WithMany(p => p.Payments);

        builder.HasOne(p => p.PaymentType)
            .WithMany(p => p.Payments);
        
        
        builder.Ignore(p => p.Notifications);
    }
}