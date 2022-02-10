namespace Infra.Context.Models;

public class PaymentType : BaseEntity
{
    public PaymentType()
    {
        
    }

    public PaymentType(string name, string description)
    {
        if(string.IsNullOrWhiteSpace(name)) AddNotification(name, "Empty name");
        if(string.IsNullOrWhiteSpace(description)) AddNotification(description, "Empty description");

        Name = name;
        Description = description;
    }
    public string Name { get; set; }= string.Empty;
    public string Description { get; set; } = string.Empty;


    public IList<Payment> Payments { get; set; } = new List<Payment>();
}