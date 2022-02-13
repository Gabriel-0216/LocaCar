namespace LocaCar.WebApp.Services.AccountServices.Dtos.Response;

public class UserLoginResponseDto
{
    public UserLoginResponseDto()
    {

    }
    public UserLoginResponseDto(string id, string email, string name, string jwtToken, DateTime validDate)
    {
        Id = id;
        Email = email;
        Name = name;
        JwtToken = jwtToken;
        ValidDate = validDate;
    }

    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string JwtToken { get; set; } = string.Empty;
    public DateTime ValidDate { get; set; } 
}