namespace Domain.Commands.Responses.GenericResponses;

public class Response
{
    public void SetSuccess()
    {
        Success = true;
    }

    public void AddError(string message)
    {
        if (!string.IsNullOrWhiteSpace(message)) Errors.Add(new Error(message));
    }

    public void SetInternalError()
    {
        Success = false;
        AddError("Internal server error");
    }

    public int Id { get; set; }
    public bool Success { get; set; } = false;
    public List<Error> Errors { get; private set; } = new List<Error>();
    public DateTime CreateDate { get; set; }
}