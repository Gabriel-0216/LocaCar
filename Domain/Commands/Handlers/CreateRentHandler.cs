using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.DomainMethods;
using Domain.Dto;
using Infra.Context.Models;
using Infra.Context.Repositories.ClientRepo;
using Infra.Context.Repositories.RentRepo;
using MediatR;

namespace Domain.Commands.Handlers;

public class CreateRentHandler : IRequestHandler<CreateRentRequest, CreateRentResponse>
{
    private readonly ICalculateValue _calculator;
    private readonly IGetVehiclesToDto _vehicleToDtoSvc;
    private readonly IClientRepository _clientRepo;
    private readonly IRentRepository _rentRepo;

    public CreateRentHandler(ICalculateValue calculator, IGetVehiclesToDto vehicleToDtoSvc, IClientRepository clientRepo, IRentRepository rentRepo)
    {
        _calculator = calculator;
        _vehicleToDtoSvc = vehicleToDtoSvc;
        _clientRepo = clientRepo;
        _rentRepo = rentRepo;
    }

    public async Task<CreateRentResponse> Handle(CreateRentRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateRentResponse();
        if (request.Vehicles.Count <= 0) response.AddError("Vehicle count less than zero");

        if (await _clientRepo.GetById(request.ClientId, false, false, false) is null)
        {
            response.AddError("Client don't exists");
        }

        if (await _clientRepo.GetById(request.Payment.ClientPaymentId, false, false, false) is null)
        {
            response.AddError("Client payment don't exists");
        }

        var vehicles = await _vehicleToDtoSvc.VehiclesToDto(request.Vehicles);
        if (vehicles.Count <= 0) response.AddError("Vehicle count less than zero");
        
        if(request.RentDate > request.DevolutionDate) response.AddError("The start date cant be higher than devolution date");

        if (response.Errors.Count > 0) return response;

        var calculateValue = _calculator.CalculateTotalValue(vehicles, request.RentDate, request.DevolutionDate);

        if (calculateValue != request.Payment.Value)
        {
            response.AddError($"The total to pay is: {calculateValue}, but the total from the payment was {request.Payment.Value}");
            return response;
        }

        var vehiclesList = await _vehicleToDtoSvc.VehicleDtoToModel(request.Vehicles);
        var payment = new Payment(0, request.Payment.ClientPaymentId, request.Payment.PaymentTypeId,
            request.Payment.Value, DateTime.UtcNow);
        var rent = new Rent(0, request.ClientId, false, request.RentDate, DateTime.Now, request.DevolutionDate, payment, DateTime.UtcNow);
        rent.SetVehicleList(vehiclesList);
        var inserted = await _rentRepo.Add(rent);
        if (inserted is not null)
        {
            response.SetSuccess(inserted.Id, inserted.ClientId, inserted.Payment.Value, inserted.RentStartDate, inserted.DevolutionExpectedAt);
            return response;
        }
        response.SetInternalError();
        return response;

    }
    
}