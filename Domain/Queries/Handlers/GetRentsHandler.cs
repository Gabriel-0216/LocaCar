using Domain.Queries.Query;
using Infra.Context.Models;
using Infra.Context.Repositories.RentRepo;
using MediatR;

namespace Domain.Queries.Handlers;

public class GetRentsHandler : IRequestHandler<GetRentsQuery, IEnumerable<Rent>>
{
    private readonly IRentRepository _rentsRepo;

    public GetRentsHandler(IRentRepository rentsRepo)
    {
        _rentsRepo = rentsRepo;
    }

    public async Task<IEnumerable<Rent>> Handle(GetRentsQuery request, CancellationToken cancellationToken)
    {
        return await _rentsRepo.Get(request.IncludeClient, request.IncludePayment, request.IncludeVehicles, request.Skip, request.Take);
    }
}