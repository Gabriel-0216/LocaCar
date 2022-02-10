using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests;

public class UpdateCategoryRequest : IRequest<UpdateCategoryResponse>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}