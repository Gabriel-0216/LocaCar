using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Infra.Context.Models;
using Infra.Context.Repositories.ClientRepo;
using MediatR;

namespace Domain.Commands.Handlers;

public class CreateClientHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
{
    private readonly IClientRepository _clientRepo;

    public CreateClientHandler(IClientRepository clientRepo)
    {
        _clientRepo = clientRepo;
    }

    public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateClientResponse();
        var client = new Client(0, request.BirthDate, request.FirstName, request.LastName,
            request.PhoneNumber, request.Email, request.City, request.Street, request.District, request.Number,
            request.ZipCode, request.Country);
        if (client.IsValid)
        {
            var inserted = await _clientRepo.Add(client);
            if (inserted is not null)
            {
                response.SetSuccess(inserted.Id, inserted.Name.FirstName, inserted.EmailAddress.EmailAddress);
                return response;
            }
            response.SetInternalError();
            return response;
        }

        foreach (var item in client.Notifications)
        {
            response.AddError(item.Message);
        }

        return response;
    }
}