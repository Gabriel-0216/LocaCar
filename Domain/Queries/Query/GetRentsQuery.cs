using Infra.Context.Models;
using MediatR;

namespace Domain.Queries.Query;

public class GetRentsQuery : Pagination, IRequest<IEnumerable<Rent>>
{
    public GetRentsQuery(bool includeClient, bool includePayment, bool includeVehicle, int skip, int take)
    {
        IncludeClient = includeClient;
        IncludePayment = includePayment;
        Skip = skip;
        Take = take;
        IncludeVehicles = includeVehicle;
    }
    public bool IncludeClient { get; set; }
    public bool IncludePayment { get; set; }
    public bool IncludeVehicles { get; set; }
}