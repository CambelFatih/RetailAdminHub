using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest <ApiResponse<CreateProductCommandResponse>>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
