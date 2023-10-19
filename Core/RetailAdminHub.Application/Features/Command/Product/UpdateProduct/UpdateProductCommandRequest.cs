using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<ApiResponse<UpdateProductCommandResponse>>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; }
    public float Price { get; set; }
}

