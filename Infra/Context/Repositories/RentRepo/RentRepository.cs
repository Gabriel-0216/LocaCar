using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context.Repositories.RentRepo;

public class RentRepository : IRentRepository
{
    private readonly AppDbContext _context;

    public RentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Rent?> Add(Rent entity)
    {
        try
        {
            _context.Rents.Add(entity);
            await _context.SaveChangesAsync();
            return await _context.Rents
                .AsNoTracking()
                .Include(p=> p.Payment)
                .FirstOrDefaultAsync(p => p.Id == entity.Id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> Remove(Rent entity)
    {
        try
        {
            _context.Rents.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Rent?> Update(Rent entity)
    {
        try
        {
            _context.Rents.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Rents
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == entity.Id);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Rent?> GetById(int id, bool includeClient, bool includePayment, bool includeVehicles, bool asNoTracking)
    {
        IQueryable<Rent> query = _context.Rents;
        if (includeClient) query = query.Include(p => p.Client);
        if (includePayment) query = query.Include(p => p.Payment);
        if (includeVehicles) query = query.Include(p => p.Vehicles);
        if (asNoTracking) query = query.AsNoTracking();

        return await query
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Rent>> Get(bool includeClient, bool includePayment, bool includeVehicles, int skip, int take)
    {
        IQueryable<Rent> query = _context.Rents;
        if (includeClient) query = query.Include(p => p.Client);
        if (includePayment) query = query.Include(p => p.Payment);
        if (includeVehicles) query = query.Include(p => p.Vehicles);

        return await query.ToListAsync();
    }
}