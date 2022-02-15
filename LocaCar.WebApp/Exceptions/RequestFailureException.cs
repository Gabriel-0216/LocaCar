namespace LocaCar.WebApp.Exceptions;

[Serializable]
public class RequestFailureException : Exception
{
    public RequestFailureException() : base("Request failure, try again later")
    {
        
    }
}