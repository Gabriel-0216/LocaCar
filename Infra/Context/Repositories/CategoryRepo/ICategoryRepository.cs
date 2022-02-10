using Infra.Context.Models;

namespace Infra.Context.Repositories.CategoryRepo;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category?> GetById(int id, bool asNoTracking, bool includeVehicles);
    Task<IEnumerable<Category>> Get(bool asNoTracking, bool includeVehicles, int skip, int take);
    
}