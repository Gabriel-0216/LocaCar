namespace LocaCar.WebApp.Services.CategoryServices.Dtos.Request;

public class CreateCategoryRequest
{
    public CreateCategoryRequest(string name, string description, decimal dailyValue)
    {
        Name = name;
        Description = description;
        DailyValue = dailyValue;
    }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal DailyValue { get; set; }
}