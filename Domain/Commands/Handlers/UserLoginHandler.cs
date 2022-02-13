using Domain.Commands.Requests;
using Domain.DomainMethods.JwtToken;
using Infra.Context.Models;
using Infra.Context.UsersCommon;
using MediatR;
using UserLoginResponse = Domain.Commands.Responses.UserLoginResponse;

namespace Domain.Commands.Handlers;

public class UserLoginHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly IUserLogin _login;
    private readonly IJwtService _jwtService;

    public UserLoginHandler(IUserLogin login, IJwtService jwtService)
    {
        _login = login;
        _jwtService = jwtService;
    }

    public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var response = new UserLoginResponse();
        var login = await _login.Login(new User(request.Email, request.Password));
        if (login is null)
        {
            return response;
        }
        
        var token = _jwtService.GenerateToken(login.Id, login.Email, login.Name);
        response.SetSuccess(login.Id, login.Email, login.Name, token.Token, token.ExpireDateTime);
        return response;
    }
}