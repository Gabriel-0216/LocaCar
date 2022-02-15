namespace LocaCar.WebApp.Exceptions;

[Serializable]
public class UnauthorizedJwtException : Exception
{
    public UnauthorizedJwtException() : base("Jwt Token is invalid")
    {

    }
}