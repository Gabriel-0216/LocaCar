using Flunt.Notifications;

namespace Infra.Context.Models.ValueObjects;

public class Email : Notifiable<Notification>
{
    public Email()
    {
        
    }

    public Email(string email)
    {
        if(string.IsNullOrWhiteSpace(email)) AddNotification(email, "Email empty");

        EmailAddress = email;
    }

    public string EmailAddress { get; set; } = string.Empty;
}