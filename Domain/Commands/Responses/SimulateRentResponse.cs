using Domain.Commands.Responses.GenericResponses;
using Domain.Dto;

namespace Domain.Commands.Responses;

public class SimulateRentResponse : Response
{
    public void SetSuccess(DateTime startDate, DateTime devolutionDate, decimal totalValue)
    {
        base.SetSuccess();
        StartDate = startDate;
        DevolutionDate = devolutionDate;
        TotalValue = totalValue;
    }

    public void AddVehicle(int id)
    {
        Vehicles.Add(new VehicleDto(id));
    }

    public IList<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();
    public DateTime StartDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public decimal TotalValue { get; set; }
}