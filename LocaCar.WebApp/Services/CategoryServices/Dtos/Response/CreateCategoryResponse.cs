namespace LocaCar.WebApp.Services.CategoryServices.Dtos.Response;

public class CreateCategoryResponse : DtoResponse
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}