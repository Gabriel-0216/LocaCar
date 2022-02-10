namespace Domain.Dto;

public class PaymentDto
{
    public int ClientPaymentId { get; set; }
    public int PaymentTypeId { get; set; }
    public decimal Value { get; set; }
}