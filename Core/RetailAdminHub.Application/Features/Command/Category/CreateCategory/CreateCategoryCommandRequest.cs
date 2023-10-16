using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Category.CreateCategory;

public class CreateCategoryCommandRequest : IRequest<ApiResponse<CreateCategoryCommandResponse>>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

