using Flunt.Notifications;

namespace Infra.Context.Models;

public class User : Notifiable<Notification>
{
    public User()
    {
        
    }

    public User(string email, string password)
    {
        if(string.IsNullOrWhiteSpace(email)) AddNotification(email, "empty email");
        
        if(string.IsNullOrWhiteSpace(password)) AddNotification(password, "empty password");

        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UserResponse : Notifiable<Notification>
{
    public UserResponse()
    {
        
    }
    public UserResponse(string id, string name, string email)
    {
        Id = id;
        Email = email;
        Name = name;
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
public class UserRegisterDto : User
{
    public UserRegisterDto(string name, string email, string password, string cellPhone)
    {
        if(string.IsNullOrWhiteSpace(name)) AddNotification(name, "empty name");
        if(string.IsNullOrWhiteSpace(email)) AddNotification(email, "empty email");
        if(string.IsNullOrWhiteSpace(password)) AddNotification(password, "empty password");
        if(string.IsNullOrWhiteSpace(cellPhone)) AddNotification(cellPhone, "empty cellPhone");

        Name = name;
        Email = email;
        Password = password;
        CellPhone = cellPhone;
    }
    public string Name { get; set; }
    public string CellPhone { get; set; }
}