using Flunt.Notifications;

namespace Infra.Context.Models.ValueObjects;

public class Name : Notifiable<Notification>
{
    public Name()
    {
        
    }

    public Name(string firstName, string lastName)
    {
        if(string.IsNullOrWhiteSpace(firstName)) AddNotification(firstName, "First name empty");
        if(string.IsNullOrWhiteSpace(lastName)) AddNotification(lastName, "Last name empty");

        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; set; }= string.Empty;
    public string LastName { get; set; } = string.Empty;
}