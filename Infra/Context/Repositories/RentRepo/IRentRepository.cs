using Infra.Context.Models;

namespace Infra.Context.Repositories.RentRepo;

public interface IRentRepository : IGenericRepository<Rent>
{
    Task<Rent?> GetById(int id, bool includeClient, bool includePayment, bool includeVehicles, bool asNoTracking);
    Task<IEnumerable<Rent>> Get(bool includeClient, bool includePayment, bool includeVehicles, int skip, int take);
}