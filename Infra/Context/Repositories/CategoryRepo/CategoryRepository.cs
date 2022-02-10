using Infra.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context.Repositories.CategoryRepo;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Category?> Add(Category entity)
    {
        try
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == entity.Id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<bool> Remove(Category entity)
    {
        try
        {
            _context.Categories.Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<Category?> Update(Category entity)
    {
        try
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == entity.Id);

        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<Category?> GetById(int id, bool asNoTracking, bool includeVehicles)
    {
        IQueryable<Category> query = _context.Categories;
        if (asNoTracking) query = query.AsNoTracking();
        if (includeVehicles) query = query.Include(p => p.Vehicles);

        return await query.FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<IEnumerable<Category>> Get(bool asNoTracking, bool includeVehicles, int skip, int take)
    {
        IQueryable<Category> query = _context.Categories;
        if (asNoTracking) query = query.AsNoTracking();
        if (includeVehicles) query = query.Include(p => p.Vehicles);

        return await query
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}