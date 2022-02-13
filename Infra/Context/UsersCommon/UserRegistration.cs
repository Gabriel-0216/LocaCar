using Infra.Context.Models;
using Microsoft.AspNetCore.Identity;

namespace Infra.Context.UsersCommon;

public class UserRegistration : IUserRegistration
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserRegistration(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserResponse?> Registration(UserRegisterDto registration)
    {
        var registrationResponse = new UserResponse();
        var emailExists = await _userManager.FindByEmailAsync(registration.Email);
        if (emailExists is not null)
        {
            registrationResponse.AddNotification(registration.Email, "email already exists");
            return registrationResponse;
        }

        var createUser = await _userManager.CreateAsync(new IdentityUser()
        {
            UserName = registration.Name,
            Email = registration.Email,
            PhoneNumber = registration.CellPhone,
        }, registration.Password);

        if (createUser.Succeeded)
        {
            var userExists = await _userManager.FindByEmailAsync(registration.Email);
            registrationResponse.Id = userExists.Id;
            registrationResponse.Email = userExists.Email;
            registrationResponse.Name = userExists.UserName;
            return registrationResponse;
        }
        registrationResponse.AddNotification("Register", "failed");
        return registrationResponse;

    }
}