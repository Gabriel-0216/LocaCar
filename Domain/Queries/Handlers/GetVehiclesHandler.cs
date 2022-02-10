using Domain.Queries.Query;
using Infra.Context.Models;
using Infra.Context.Repositories.VehicleRepo;
using MediatR;

namespace Domain.Queries.Handlers;

public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, IEnumerable<Vehicle>>
{
    private readonly IVehicleRepository _vehicleRepo;

    public GetVehiclesHandler(IVehicleRepository vehicleRepo)
    {
        _vehicleRepo = vehicleRepo;
    }

    public async Task<IEnumerable<Vehicle>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        return await _vehicleRepo.Get(request.IncludeCategory, request.IncludeFuelType, request.IncludeRents);
    }
}