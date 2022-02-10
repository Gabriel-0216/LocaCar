namespace Infra.Context.Models;

public class Vehicle : BaseEntity
{
    public Vehicle()
    {
        
    }

    public Vehicle(int id, string brand, string model, int year, int categoryId, int fuelTypeId, 
        string imageUrl, bool isAvailable, DateTime createDate, DateTime updateDate)
    {
        Id = id;
        SetBrand(brand);
        SetModel(model);

        Year = year;
        CategoryId = categoryId;
        FuelTypeId = fuelTypeId;
        ImageUrl = imageUrl;
        IsAvailable = isAvailable;
        CreateDate = createDate;
        UpdateDate = updateDate;
    }

    private void SetBrand(string brand)
    {
        if(string.IsNullOrWhiteSpace(brand)) AddNotification(brand, "empty brand");
        Brand = brand;
    }

    private void SetModel(string model)
    {
        if(string.IsNullOrWhiteSpace(model)) AddNotification(model, "empty model");
        Model = model;
    }
    

    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string ImageUrl { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
    public int FuelTypeId { get; set; }
    public FuelType FuelType { get; set; }


    public IList<Rent> Rents { get; set; }
}