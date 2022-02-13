using LocaCar.WebApp.Services.AccountServices.Dtos.Request;
using LocaCar.WebApp.Services.AccountServices.Dtos.Response;

namespace LocaCar.WebApp.Services.AccountServices
{
    public interface IAccountService
    {
        Task<UserRegisterResponseDto> UserRegisterService(UserRegisterPostDto registerPost);
        Task<UserLoginResponseDto> UserLoginService(UserLoginPostDto loginPost);
    }
}
