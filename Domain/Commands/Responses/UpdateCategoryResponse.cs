using Domain.Commands.Responses.GenericResponses;

namespace Domain.Commands.Responses;

public class UpdateCategoryResponse : Response
{

    public void SetSuccess(int id, string name, string description, DateTime createDate)
    {
        base.SetSuccess();
        Id = id;
        Name = name;
        Description = description;
        CreateDate = createDate;
    }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}