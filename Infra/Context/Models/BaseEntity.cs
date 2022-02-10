using Flunt.Notifications;

namespace Infra.Context.Models;

public class BaseEntity : Notifiable<Notification>
{
    public int Id { get; set; }
}