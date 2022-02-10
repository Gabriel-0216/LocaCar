using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests;

public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal DailyValue { get; set; }
}