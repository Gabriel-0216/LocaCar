using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings;

public class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.OwnsOne(p => p.Name, name =>
        {
            name.Property(c => c.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            name.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            name.Ignore(p => p.Notifications);
        });

        builder.Property(p => p.BirthDate)
            .HasColumnName("Birthdate")
            .HasColumnType("DATETIME")
            .IsRequired();

        builder
            .OwnsOne(p => p.Address, address =>
            {
                address.Property(p => p.City)
                    .HasColumnName("City")
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();

                address.Property(p => p.Street)
                    .HasColumnName("Street")
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();

                address.Property(p => p.District)
                    .HasColumnName("District")
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();

                address.Property(p => p.ZipCode)
                    .HasColumnName("ZipCode")
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .IsRequired();

                address.Property(p => p.Country)
                    .HasColumnName("Country")
                    .HasColumnType("varchar")
                    .HasMaxLength(20);

                address.Property(p => p.Number)
                    .HasColumnName("Number")
                    .HasColumnType("smallint")
                    .IsRequired();

                address.Ignore(p => p.Notifications);

            });

        builder.OwnsOne(p => p.PhoneNumber, phone =>
        {
            phone.Property(p => p.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            phone.Ignore(p => p.Notifications);
        });

        builder.OwnsOne(p => p.EmailAddress, email =>
        {
            email.Property(p => p.EmailAddress)
                .HasColumnName("EmailAddress")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            email.Ignore(p => p.Notifications);
        });
        
        builder.HasMany(p => p.Rents)
            .WithOne(p => p.Client)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.Payments)
            .WithOne(p => p.Client);

        builder.Ignore(p => p.Notifications);


    }
}