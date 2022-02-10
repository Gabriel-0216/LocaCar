using Domain.Dto;
using Infra.Context.Models;
using Infra.Context.Repositories.VehicleRepo;

namespace Domain.DomainMethods;

public class GetVehiclesToDto : IGetVehiclesToDto
{
    private readonly IVehicleRepository _vehicleRepo;

    public GetVehiclesToDto(IVehicleRepository vehicleRepo)
    {
        _vehicleRepo = vehicleRepo;
    }

    public async Task<IList<VehicleCalculateDto>> VehiclesToDto(IList<VehicleDto> vehicles)
    {
        var vehiclesList = new List<VehicleCalculateDto>();
        foreach (var item in vehicles)
        {
            var vehicle = await _vehicleRepo.GetById(item.VehicleId, false, true,
                false, false);
            if (vehicle is not null)
            {
                vehiclesList.Add(new VehicleCalculateDto(vehicle.Id, vehicle.Category.DailyValue));
            }
        }

        return vehiclesList;
    }

    public async Task<IList<Vehicle>> VehicleDtoToModel(IList<VehicleDto> vehicles)
    {
        var vehiclesList = new List<Vehicle>();
        foreach (var item in vehicles)
        {
            var vehicle = await _vehicleRepo.GetById(item.VehicleId, false, false, false, false);
            if (vehicle is not null)
            {
                vehiclesList.Add(vehicle);
            }
        }

        return vehiclesList;
    }
}