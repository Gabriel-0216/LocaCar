namespace LocaCar.WebApp.Services.AccountServices.Dtos.Request;

public class UserLoginPostDto
{
    public UserLoginPostDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; } 
    public string Password { get; set; }
}