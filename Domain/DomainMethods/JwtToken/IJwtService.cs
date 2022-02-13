using Microsoft.AspNetCore.Identity;

namespace Domain.DomainMethods.JwtToken;

public interface IJwtService
{
    JwtToken GenerateToken(string id, string email, string userName);
}