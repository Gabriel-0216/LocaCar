namespace Infra.Context.Models;

public class Rent : BaseEntity
{
    public Rent()
    {
        
    }

    public Rent(int id, int clientId, int paymentId, bool isFinished, DateTime rentStartDate,
        DateTime devolutionDate, DateTime devolutionExpectedAt, DateTime rentDate)
    {
        Id = id;
        ClientId = clientId;
        PaymentId = paymentId;
        IsFinished = isFinished;
        RentDate = rentDate;
        RentStartDate = rentStartDate;
        DevolutionDate = devolutionDate;
        DevolutionExpectedAt = devolutionExpectedAt;
    }

    public Rent(int id, int clientId, bool isFinished, DateTime rentStartDate, DateTime devolutionDate, DateTime devolutionExpectedAt, Payment payment, DateTime rentDate)
    {
        Id = id;
        ClientId = clientId;
        IsFinished = isFinished;
        RentStartDate = rentStartDate;
        DevolutionDate = devolutionDate;
        DevolutionExpectedAt = devolutionExpectedAt;
        Payment = payment;
        RentDate = rentDate;

        
    }

    public void SetVehicleList(IList<Vehicle> vehicles)
    {
        Vehicles = vehicles;
    }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int PaymentId { get; set; }
    public Payment Payment { get; set; }
    public bool IsFinished { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DevolutionExpectedAt { get; set; }
    public DateTime DevolutionDate { get; set; }

    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

}