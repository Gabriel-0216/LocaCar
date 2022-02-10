using Infra.Context.Models;

namespace Infra.Context.Repositories.FuelTypeRepo;

public interface IFuelTypeRepository : IGenericRepository<FuelType>
{
    Task<FuelType?> GetFuelType(int id, bool asNoTracking, bool includeVehicles);
    Task<IEnumerable<FuelType>> GetFuelTypes(bool includeVehicles, int skip, int take);
}