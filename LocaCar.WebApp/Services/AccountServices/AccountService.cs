using System.Text.Json;
using LocaCar.WebApp.Exceptions;
using LocaCar.WebApp.Services.AccountServices.Dtos.Request;
using LocaCar.WebApp.Services.AccountServices.Dtos.Response;
using LocaCar.WebApp.Services.AccountServices.Endpoints;

namespace LocaCar.WebApp.Services.AccountServices;

public class AccountService : IAccountService
{
    private readonly IHttpClientFactory _clientFactory;

    public AccountService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<UserRegisterResponseDto> UserRegisterService(UserRegisterPostDto registerPost)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.PostAsJsonAsync(AccountsEndpoint.Register, registerPost);

        if (!response.IsSuccessStatusCode) throw new Exception("Register failed");

        var deserialize =
            await JsonSerializer.DeserializeAsync<UserRegisterResponseDto>(await response.Content.ReadAsStreamAsync(), DeserializerSettings.GetOptions());

        return deserialize ?? throw new Exception("Failed to deserialize");
    }

    public async Task<UserLoginResponseDto> UserLoginService(UserLoginPostDto loginPost)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.PostAsJsonAsync(AccountsEndpoint.Login, loginPost);
        
        if (!response.IsSuccessStatusCode) throw new Exception("Login failed");
        
        var deserialize = await JsonSerializer.DeserializeAsync<UserLoginResponseDto>(await response.Content.ReadAsStreamAsync(),
            DeserializerSettings.GetOptions());

        return deserialize ?? throw new RequestFailureException();

    }
}