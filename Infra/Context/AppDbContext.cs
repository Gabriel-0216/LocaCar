using Infra.Context.Mappings;
using Infra.Context.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base (options)
    {
        
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new ClientMap());
        modelBuilder.ApplyConfiguration(new FuelTypeMap());
        modelBuilder.ApplyConfiguration(new PaymentMap());
        modelBuilder.ApplyConfiguration(new PaymentTypeMap());
        modelBuilder.ApplyConfiguration(new RentMap());
        modelBuilder.ApplyConfiguration(new VehicleMap());
    }
}