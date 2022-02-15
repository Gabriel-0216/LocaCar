namespace LocaCar.WebApp.Services;

public class DtoResponse
{
    public int Id { get; set; }
    public bool Success { get; set; } = false;
    public List<Error> Errors { get; private set; } = new List<Error>();
    public DateTime CreateDate { get; set; }
}
public class Error
{
    public Error(string message)
    {
        if (!string.IsNullOrWhiteSpace(message)) ErrorMessage = message;
    }
    public string ErrorMessage { get; set; } = string.Empty;
}