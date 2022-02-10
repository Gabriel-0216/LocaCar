using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Infra.Context.Repositories.CategoryRepo;
using MediatR;

namespace Domain.Commands.Handlers;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepo;

    public DeleteCategoryHandler(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = new DeleteCategoryResponse();

        var categoryExists = await _categoryRepo.GetById(request.Id, false, false);
        if (categoryExists is null)
        {
            response.AddError("Category don't exists, delete failed");
            return response;
        }

        if (await _categoryRepo.Remove(categoryExists))
        {
            response.SetSuccess();
            return response;
        }
        response.SetInternalError();
        return response;
    }
}