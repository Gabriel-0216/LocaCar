using Infra.Context.Models;

namespace Infra.Context.Repositories.ClientRepo;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<Client?> GetById(int id, bool asNoTracking, bool includeRents, bool includePayments);
    Task<IEnumerable<Client>> Get(bool includeRents, bool includePayments);
}