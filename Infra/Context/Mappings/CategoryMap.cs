using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(p => p.Description)
            .HasColumnName("Description")
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.DailyValue)
            .IsRequired()
            .HasColumnName("DailyValue")
            .HasColumnType("decimal")
            .IsRequired();

        builder.Property(p => p.UpdateDate)
            .IsRequired()
            .HasColumnName("UpdateDate")
            .IsRequired()
            .HasColumnType("DATETIME");
        
        builder.Property(p => p.CreateDate)
            .IsRequired()
            .HasColumnName("CreateDate")
            .IsRequired()
            .HasColumnType("DATETIME");


        builder.HasMany(p => p.Vehicles)
            .WithOne(p => p.Category)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Ignore(p => p.Notifications);
        builder.Ignore(p => p.IsValid);



    }
}