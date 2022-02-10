using Infra.Context.Models;
using MediatR;

namespace Domain.Queries.Query;

public class GetVehiclesQuery : Pagination, IRequest<IEnumerable<Vehicle>>
{
    public GetVehiclesQuery(bool includeCategory, bool includeFuelType, bool includeRents, int skip, int take)
    {
        IncludeCategory = includeCategory;
        IncludeFuelType = includeFuelType;
        IncludeRents = includeRents;
        Skip = skip;
        Take = take;
    }
    public bool IncludeCategory { get; set; }
    public bool IncludeFuelType { get; set; }
    public bool IncludeRents { get; set; }

}