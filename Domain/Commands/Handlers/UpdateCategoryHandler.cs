using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Infra.Context.Models;
using Infra.Context.Repositories.CategoryRepo;
using MediatR;

namespace Domain.Commands.Handlers;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepo;

    public UpdateCategoryHandler(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = new UpdateCategoryResponse();
        var categoryExists = await _categoryRepo.GetById(request.Id, true, false);
        if (categoryExists is null)
        {
            response.AddError("Category don't exists");
            return response;
        }
        categoryExists.UpdateValidator(request.Name, request.Description);
        if (categoryExists.IsValid)
        {
            var updated = await _categoryRepo.Update(categoryExists);
            if (updated is not null)
            {
                response.SetSuccess(updated.Id, updated.Name, updated.Description, updated.CreateDate);
                return response;
            }
            response.SetInternalError();
            return response;
        }

        foreach (var item in categoryExists.Notifications)
        {
            response.AddError(item.Message);
        }

        return response;

    }
}