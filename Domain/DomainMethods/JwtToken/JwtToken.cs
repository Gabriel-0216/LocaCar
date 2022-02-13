namespace Domain.DomainMethods.JwtToken;

public class JwtToken
{
    public JwtToken(string token, DateTime valid)
    {
        Token = token;
        ExpireDateTime = valid;
    }
    public string Token { get; set; }
    public DateTime ExpireDateTime { get; set; }
}