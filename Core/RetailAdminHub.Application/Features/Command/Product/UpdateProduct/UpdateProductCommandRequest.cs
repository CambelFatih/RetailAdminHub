using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Product.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<ApiResponse<UpdateProductCommandResponse>>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}

