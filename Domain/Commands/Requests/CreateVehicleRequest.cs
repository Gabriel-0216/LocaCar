using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests;

public class CreateVehicleRequest : IRequest<CreateVehicleResponse>
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public int CategoryId { get; set; }
    public int FuelTypeId { get; set; }

}