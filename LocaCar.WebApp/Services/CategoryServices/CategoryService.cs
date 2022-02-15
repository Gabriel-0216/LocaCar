using System.Net.Http.Headers;
using System.Text.Json;
using LocaCar.WebApp.Exceptions;
using LocaCar.WebApp.Services.CategoryServices.Dtos.Request;
using LocaCar.WebApp.Services.CategoryServices.Dtos.Response;
using LocaCar.WebApp.Services.CategoryServices.Endpoints;
using Microsoft.IdentityModel.JsonWebTokens;

namespace LocaCar.WebApp.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clientFactory;

    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<CreateCategoryResponse?> CreateCategory(CreateCategoryRequest request, string accessToken)
    {
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await client.PostAsJsonAsync(CategoryEndpoints.Create, request);
        if (response.IsSuccessStatusCode)
        {
            var deserialize =
                await JsonSerializer.DeserializeAsync<CreateCategoryResponse>(await response.Content.ReadAsStreamAsync(), DeserializerSettings.GetOptions());
            return deserialize;
        }
        if (response.StatusCode.Equals(401))
        {
            throw new UnauthorizedJwtException();
        }
        throw new RequestFailureException();
    }
}