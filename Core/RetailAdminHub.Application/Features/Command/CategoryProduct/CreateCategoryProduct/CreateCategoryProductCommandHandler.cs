using MediatR;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct
{
    public class CreateCategoryProductCommandHandler : IRequestHandler<CreateCategoryProductCommandRequest, ApiResponse<CreateCategoryProductCommandResponse>>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public CreateCategoryProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<ApiResponse<CreateCategoryProductCommandResponse>> Handle(CreateCategoryProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Name = request.ProductName,
                Stock = request.Stock,
                Price = request.Price,
                IsActive = true
            };

            var categories = request.Categories.Select(c => new Domain.Entities.Category
            {
                Name = c.Name,
                Description = c.Description,
                IsActive = true
            }).ToList();

            await _productWriteRepository.AddProductWithCategories(product, categories);
            return new ApiResponse<CreateCategoryProductCommandResponse>(true);
        }
    }
}
