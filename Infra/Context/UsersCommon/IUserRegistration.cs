using Infra.Context.Models;

namespace Infra.Context.UsersCommon;

public interface IUserRegistration
{
    Task<UserResponse?> Registration(UserRegisterDto registration);
}