using Infra.Context.Models;
using Microsoft.AspNetCore.Identity;

namespace Infra.Context.UsersCommon;

public class UserLogin : IUserLogin
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserLogin(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserResponse?> Login(User user)
    {
        var userLoginResponse = new UserResponse();
        var userExists = await _userManager.FindByEmailAsync(user.Email);
        if (userExists is null)
        {
            userLoginResponse.AddNotification(user.Email, "User don't exists");
            return userLoginResponse;
        }

        var checkPassword = await _userManager.CheckPasswordAsync(userExists, user.Password);
        
        if (checkPassword) return new UserResponse(userExists.Id, userExists.UserName, userExists.Email);
        
        userLoginResponse.AddNotification(user.Email, "Login unsuccessful");
        return userLoginResponse;
    }
}