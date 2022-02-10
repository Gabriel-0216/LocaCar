namespace Domain.DomainMethods.Validator;

public sealed class CalculateValueResponse
{
    public CalculateValueResponse(decimal value, int days)
    {
        Value = value;
        Days = days;
    }
    public decimal Value { get; set; }
    public int Days { get; set; }
}