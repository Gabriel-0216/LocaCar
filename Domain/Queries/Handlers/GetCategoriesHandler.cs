using Domain.Queries.Query;
using Infra.Context.Models;
using Infra.Context.Repositories.CategoryRepo;
using MediatR;

namespace Domain.Queries.Handlers;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _categoryRepo;

    public GetCategoriesHandler(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepo.Get(false, request.IncludeVehicles, request.Skip, request.Take);
    }
}