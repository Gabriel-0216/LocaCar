using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.DomainMethods.JwtToken;
using Infra.Context.Models;
using Infra.Context.UsersCommon;
using MediatR;

namespace Domain.Commands.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUserRegistration _userRegister;
    private readonly IJwtService _jwtSvc;

    public CreateUserHandler(IUserRegistration userRegister, IJwtService jwtSvc)
    {
        _userRegister = userRegister;
        _jwtSvc = jwtSvc;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result =
            await _userRegister.Registration(new UserRegisterDto(request.Name, request.Email, request.Password, request.Cellphone));

        var response = new CreateUserResponse();
        if(result is not null)
        {
            var token = _jwtSvc.GenerateToken(result.Id, result.Email, result.Name);
            response.SetSuccess(result.Id, result.Email, result.Name, token.Token, token.ExpireDateTime);
            return response;
        }
        response.SetInternalError();
        return response;
    }
}