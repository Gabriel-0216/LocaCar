using Infra.Context.Models;

namespace Infra.Context.Repositories.VehicleRepo;

public interface IVehicleRepository : IGenericRepository<Vehicle>
{
    Task<Vehicle?> GetById(int id, bool asNoTracking, bool includeCategory, bool includeFuelType, bool includeRents);
    Task<IEnumerable<Vehicle>> Get(bool includeCategory, bool includeFuelType, bool includeRents);
}