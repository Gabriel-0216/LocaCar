namespace Domain.Commands.Responses.GenericResponses;

public class Error
{
    public Error(string message)
    {
        if (!string.IsNullOrWhiteSpace(message)) ErrorMessage = message;
    }
    public string ErrorMessage { get; set; } = string.Empty;
}