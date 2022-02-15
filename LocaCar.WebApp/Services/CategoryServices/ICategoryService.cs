using LocaCar.WebApp.Services.CategoryServices.Dtos.Request;
using LocaCar.WebApp.Services.CategoryServices.Dtos.Response;

namespace LocaCar.WebApp.Services.CategoryServices;

public interface ICategoryService
{
    Task<CreateCategoryResponse?> CreateCategory(CreateCategoryRequest request, string accessToken);
}