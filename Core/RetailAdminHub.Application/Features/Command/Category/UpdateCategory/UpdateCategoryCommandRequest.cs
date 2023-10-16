
using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Category.UpdateCategory;

public class UpdateCategoryCommandRequest : IRequest<ApiResponse<UpdateCategoryCommandResponse>>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

