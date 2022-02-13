using Domain.Commands.Responses.GenericResponses;

namespace Domain.Commands.Responses;

public class CreateUserResponse : UserResponse
{
   public void SetSuccess(string id, string email, string name, string jwtToken, DateTime tokenExpireDate)
   {
      base.SetSuccess();
      Id = id;
      Email = email;
      Name = name;
      JwtToken = jwtToken;
      ValidDate = tokenExpireDate;
   }
   
}