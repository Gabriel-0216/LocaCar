using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context.Repositories.VehicleRepo;

public class VehicleRepository : IVehicleRepository
{
    private readonly AppDbContext _context;

    public VehicleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Vehicle?> Add(Vehicle entity)
    {
        try
        {
            _context.Vehicles.Add(entity);
            await _context.SaveChangesAsync();
            return await _context.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == entity.Id);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> Remove(Vehicle entity)
    {
        try
        {
            _context.Vehicles.Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Vehicle?> Update(Vehicle entity)
    {
        try
        {
            _context.Vehicles.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Vehicles.AsNoTracking().FirstOrDefaultAsync(p => p.Id == entity.Id);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Vehicle?> GetById(int id, bool asNoTracking, bool includeCategory, bool includeFuelType, bool includeRents)
    {
        IQueryable<Vehicle> query = _context.Vehicles;
        if (asNoTracking) query = query.AsNoTracking();
        if (includeCategory) query = query.Include(p => p.Category);
        if (includeFuelType) query = query.Include(p => p.FuelType);
        if (includeRents) query = query.Include(p => p.Rents);

        return await query.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Vehicle>> Get(bool includeCategory, bool includeFuelType, bool includeRents)
    {
        IQueryable<Vehicle> query = _context.Vehicles;
        if (includeCategory) query = query.Include(p => p.Category);
        if (includeFuelType) query = query.Include(p => p.FuelType);
        if (includeRents) query = query.Include(p => p.Rents);

        return await query.ToListAsync();
    }
}