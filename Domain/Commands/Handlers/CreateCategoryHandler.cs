using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Commands.Responses.GenericResponses;
using Infra.Context.Models;
using Infra.Context.Repositories.CategoryRepo;
using MediatR;

namespace Domain.Commands.Handlers;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepo;

    public CreateCategoryHandler(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateCategoryResponse();
        var category = new Category(0, request.Name, request.Description, request.DailyValue, DateTime.UtcNow,
            DateTime.UtcNow);

        if (category.IsValid)
        {
            
            var inserted = await _categoryRepo.Add(category);
            if (inserted is not null)
            {
               
                response.SetSuccess(inserted.Id, inserted.Name, inserted.Description, inserted.CreateDate);
                return response;
            }
            response.SetInternalError();
            return response;
        }

        foreach (var item in category.Notifications)
        {
            response.AddError(item.Message);
        }

        return response;
    }
}