using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct
{
    public class CreateCategoryProductCommandRequest : IRequest<ApiResponse<CreateCategoryProductCommandResponse>>
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public List<CategoryRequest> Categories { get; set; }
    }
    public class CategoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
