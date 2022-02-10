using Infra.Context.Models;
using MediatR;

namespace Domain.Queries.Query;

public class GetCategoriesQuery : Pagination, IRequest<IEnumerable<Category>>
{
    public GetCategoriesQuery(bool includeVehicles, int skip, int take)
    {
        IncludeVehicles = includeVehicles;
        Skip = skip;
        Take = take;
    }
    public bool IncludeVehicles { get; set; }
}