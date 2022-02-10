using Domain.Commands.Responses.GenericResponses;

namespace Domain.Commands.Responses;

public class CreateRentResponse : Response
{

    public void SetSuccess(int id, int clientId, decimal totalPaid, DateTime startDate, DateTime devolutionDate)
    {
        base.SetSuccess();
        Id = id;
        ClientId = clientId;
        TotalPaid = totalPaid;
        StartDate = startDate;
        DevolutionDate = devolutionDate;
    }
    public int ClientId { get; set; }
    public decimal TotalPaid { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    
}