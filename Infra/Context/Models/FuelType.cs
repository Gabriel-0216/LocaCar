namespace Infra.Context.Models;

public class FuelType : BaseEntity
{
    public FuelType()
    {
        
    }
    public FuelType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) AddNotification(name, "Empty name");
        Name = name;
    }
    public string Name { get; set; } = string.Empty;

    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}