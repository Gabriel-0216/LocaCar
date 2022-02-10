using Domain.Commands.Responses.GenericResponses;

namespace Domain.Commands.Responses;

public class CreateVehicleResponse : Response
{
    public string Brand { get; set; }= string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }

    public void SetSuccess(int id, string brand, string model, int year)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        base.SetSuccess();
    }
}