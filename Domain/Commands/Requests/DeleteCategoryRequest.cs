using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests;

public class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
{
    public int Id { get; set; }
}