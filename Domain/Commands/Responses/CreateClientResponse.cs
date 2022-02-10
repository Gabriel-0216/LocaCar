using Domain.Commands.Responses.GenericResponses;

namespace Domain.Commands.Responses;

public class CreateClientResponse : Response
{
    public void SetSuccess(int id, string firstName, string email)
    {
        base.SetSuccess();
        Id = id;
        FirstName = firstName;
        Email = email;
    }
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}