namespace Infra.Context.Models;

public class Payment : BaseEntity
{
    public Payment()
    {
        
    }

    public Payment(int id, int clientId, int paymentTypeId, decimal value, DateTime paymentDate)
    {
        Id = id;
        ClientId = clientId;
        PaymentTypeId = paymentTypeId;
        Value = value;
        PaymentDate = paymentDate;
    }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Value { get; set; }
}