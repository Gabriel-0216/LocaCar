using Flunt.Notifications;

namespace Infra.Context.Models.ValueObjects;

public class Phone : Notifiable<Notification>
{
    public Phone()
    {
        
    }

    public Phone(string phoneNumber)
    {
        if(string.IsNullOrWhiteSpace(phoneNumber)) AddNotification(phoneNumber, "Phone number empty");

        PhoneNumber = phoneNumber;
    }
    public string PhoneNumber { get; set; } = string.Empty;
}