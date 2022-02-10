using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context.Repositories.FuelTypeRepo;

public class FuelTypeRepository : IFuelTypeRepository
{
    private readonly AppDbContext _context;

    public FuelTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<FuelType?> Add(FuelType entity)
    {
        try
        {
            _context.FuelTypes.Add(entity);
            await _context.SaveChangesAsync();
            return await _context.FuelTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == entity.Id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> Remove(FuelType entity)
    {
        try
        {
            _context.FuelTypes.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<FuelType?> Update(FuelType entity)
    {
        try
        {
            _context.FuelTypes.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.FuelTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == entity.Id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<FuelType?> GetFuelType(int id, bool asNoTracking, bool includeVehicles)
    {
        IQueryable<FuelType> query = _context.FuelTypes;
        if (asNoTracking) query = query.AsNoTracking();
        if (includeVehicles) query = query.Include(p => p.Vehicles);

        return await query
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<FuelType>> GetFuelTypes(bool includeVehicles, int skip, int take)
    {
        IQueryable<FuelType> query = _context.FuelTypes;
        if (includeVehicles) query = query.Include(p => p.Vehicles);

        return await query.Skip(skip).Take(take).ToListAsync();

    }
}