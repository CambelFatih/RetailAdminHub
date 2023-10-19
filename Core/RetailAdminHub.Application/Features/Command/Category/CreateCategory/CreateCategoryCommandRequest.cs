using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Category.CreateCategory;

public class CreateCategoryCommandRequest : IRequest<ApiResponse<CreateCategoryCommandResponse>>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

