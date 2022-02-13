using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Cellphone { get; set; } = string.Empty;
    
}