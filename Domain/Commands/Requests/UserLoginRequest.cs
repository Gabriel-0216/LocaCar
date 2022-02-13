using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests;

public class UserLoginRequest : IRequest<UserLoginResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}