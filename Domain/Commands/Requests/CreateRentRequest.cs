using Domain.Commands.Responses;
using Domain.Dto;
using MediatR;

namespace Domain.Commands.Requests;

public class CreateRentRequest : IRequest<CreateRentResponse>
{
    public int ClientId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public PaymentDto Payment { get; set; }
    public IList<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();
}