

using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Category.RemoveCategory;

public class RemoveCategoryCommandRequest : IRequest<ApiResponse<RemoveCategoryCommandResponse>>
{
    public string Id { get; set; }
}

