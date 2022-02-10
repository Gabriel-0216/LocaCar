namespace Infra.Context.Models;

public class Category : BaseEntity
{
    public Category()
    {
        
    }

    public Category(int id, string name, string description, decimal dailyValue, DateTime createDate,
        DateTime updateDate)
    {
        Id = id;
        ValidateName(name);
        ValidateDescription(description);

        Name = name;
        Description = description;
        DailyValue = dailyValue;
        CreateDate = createDate;
        UpdateDate = updateDate;
    }

    public void UpdateValidator(string name, string description)
    {
        ValidateName(name);
        ValidateDescription(description);
        Name = name;
        Description = description;
    }

    private void ValidateName(string name)
    {
        if(string.IsNullOrWhiteSpace(name)) AddNotification(name, "Empty name");
    }

    private void ValidateDescription(string description)
    {
        if(string.IsNullOrWhiteSpace(description)) AddNotification(description, "Empty description");
    }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal DailyValue { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    
}