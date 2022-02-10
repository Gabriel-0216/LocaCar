using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Infra.Context.Models;
using Infra.Context.Repositories.CategoryRepo;
using Infra.Context.Repositories.FuelTypeRepo;
using Infra.Context.Repositories.VehicleRepo;
using MediatR;

namespace Domain.Commands.Handlers;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleRequest, CreateVehicleResponse>
{
    private readonly IVehicleRepository _vehicleRepo;
    private readonly ICategoryRepository _categoryRepo;
    private readonly IFuelTypeRepository _fuelTypeRepo;

    public CreateVehicleHandler(IVehicleRepository vehicleRepo, IFuelTypeRepository fuelTypeRepo, ICategoryRepository categoryRepo)
    {
        _vehicleRepo = vehicleRepo;
        _fuelTypeRepo = fuelTypeRepo;
        _categoryRepo = categoryRepo;
    }

    public async Task<CreateVehicleResponse> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateVehicleResponse();

        var vehicle = new Vehicle(0, request.Brand, request.Model, request.Year, request.CategoryId, request.FuelTypeId,
            request.ImageUrl, request.IsAvailable, DateTime.UtcNow, DateTime.UtcNow);

        var fuelTypeExists = await _fuelTypeRepo.GetFuelType(request.FuelTypeId, false, false);
        var categoryExists = await _categoryRepo.GetById(request.CategoryId, false, false);

        if (fuelTypeExists is null)
        {
            response.AddError("Fuel type don't exists");
        }

        if (categoryExists is null)
        {
            response.AddError("Category don't exists");
        }

        if (!vehicle.IsValid)
        {
            foreach (var item in vehicle.Notifications)
            {
                response.AddError(item.Message);
            }

            return response;
        }

        if (response.Errors.Count > 0) return response;

        var inserted = await _vehicleRepo.Add(vehicle);
        if (inserted is not null)
        {
            response.SetSuccess(inserted.Id, inserted.Brand, inserted.Model, inserted.Year);
            return response;
        }
        response.SetInternalError();
        return response;

    }
}