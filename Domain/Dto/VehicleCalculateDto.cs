namespace Domain.Dto;

public class VehicleCalculateDto
{
    public VehicleCalculateDto(int vehicleId, decimal dailyValue)
    {
        VehicleId = vehicleId;
        DailyValue = dailyValue;
    }
    public int VehicleId { get; set; }
    public decimal DailyValue { get; set; }
}