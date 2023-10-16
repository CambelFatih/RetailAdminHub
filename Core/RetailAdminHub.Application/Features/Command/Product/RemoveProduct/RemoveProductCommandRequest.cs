using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.RemoveProduct;

public class RemoveProductCommandRequest : IRequest<ApiResponse<RemoveProductCommandResponse>>
{
    public string Id { get; set; }
}

