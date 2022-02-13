using Infra.Context.Models;

namespace Infra.Context.UsersCommon;

public interface IUserLogin
{
    Task<UserResponse?> Login(User user);
}