using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.DomainMethods;
using MediatR;

namespace Domain.Commands.Handlers;

public class SimulateRentHandler : IRequestHandler<SimulateRentRequest, SimulateRentResponse>
{
    private readonly ICalculateValue _calculateSvc;
    private readonly IGetVehiclesToDto _vehicleToDto;

    public SimulateRentHandler(ICalculateValue calculateSvc, IGetVehiclesToDto vehicleToDto)
    {
        _calculateSvc = calculateSvc;
        _vehicleToDto = vehicleToDto;
    }

    public async Task<SimulateRentResponse> Handle(SimulateRentRequest request, CancellationToken cancellationToken)
    {
        var simulateResponse = new SimulateRentResponse();
        if (request.Vehicles.Count <= 0)
        {
            simulateResponse.AddError("Can't calculate a rent for zero vehicles");
            return simulateResponse;
        }

        if (request.StartDate > request.DevolutionDate)
        {
            simulateResponse.AddError("The start date can't be higher than devolution date");
            return simulateResponse;
        }

        var vehicles = await _vehicleToDto.VehiclesToDto(request.Vehicles);
        if (vehicles.Count <= 0)
        {
            simulateResponse.AddError("Can't calculate a rent for zero vehicles");
            return simulateResponse;
        }

        var totalValue = _calculateSvc.CalculateTotalValue(vehicles, request.StartDate, request.DevolutionDate);
        simulateResponse.SetSuccess(request.StartDate, request.DevolutionDate, totalValue);
        return simulateResponse;

    }
    
}