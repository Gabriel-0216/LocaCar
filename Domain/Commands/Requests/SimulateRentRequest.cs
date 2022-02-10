using Domain.Commands.Responses;
using Domain.Dto;
using MediatR;

namespace Domain.Commands.Requests;

public class SimulateRentRequest : IRequest<SimulateRentResponse>
{
    public IList<VehicleDto> Vehicles { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DevolutionDate { get; set; }
}