namespace Domain.Dto;

public class VehicleDto
{
    public VehicleDto()
    {
        
    }

    public VehicleDto(int id)
    {
        VehicleId = id;
    }
    public int VehicleId { get; set; }
}