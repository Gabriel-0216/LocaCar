using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context.Repositories.ClientRepo;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client?> GetById(int id, bool asNoTracking, bool includeRents, bool includePayments)
    {
        IQueryable<Client> query = _context.Clients;
        if (asNoTracking) query = query.AsNoTracking();
        if (includePayments) query = query.Include(p => p.Payments);
        if (includeRents) query = query.Include(p => p.Rents);

        return await query.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Client>> Get(bool includeRents, bool includePayments)
    {
        IQueryable<Client> query = _context.Clients;
        if (includePayments) query = query.Include(p => p.Payments);
        if (includeRents) query = query.Include(p => p.Rents);
        return await query.ToListAsync();
    }

    public async Task<Client?> Add(Client entity)
    {
        try
        {
            _context.Clients.Add(entity);
            await _context.SaveChangesAsync();
            return await _context.Clients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == entity.Id);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> Remove(Client entity)
    {
        try
        {
            _context.Clients.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch(Exception ex)
        {
            throw;
        }
    }

    public async Task<Client?> Update(Client entity)
    {
        try
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Clients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == entity.Id);

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}