using Domain.Dto;
using Infra.Context.Models;

namespace Domain.DomainMethods;

public interface IGetVehiclesToDto
{
    Task<IList<VehicleCalculateDto>> VehiclesToDto(IList<VehicleDto> vehicles);

    Task<IList<Vehicle>> VehicleDtoToModel(IList<VehicleDto> vehicles);
}