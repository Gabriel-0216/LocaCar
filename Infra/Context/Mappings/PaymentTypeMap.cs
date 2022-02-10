using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings;

public class PaymentTypeMap : IEntityTypeConfiguration<PaymentType>
{
    public void Configure(EntityTypeBuilder<PaymentType> builder)
    {
        builder.ToTable("PaymentType");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.HasMany(p => p.Payments)
            .WithOne(c => c.PaymentType)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Ignore(p => p.Notifications);
        
    }
}