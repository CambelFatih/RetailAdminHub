using MediatR;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Base.Response;
using RetailAdminHub.Domain.Entities;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct;

public class CreateCategoryProductCommandHandler : IRequestHandler<CreateCategoryProductCommandRequest, ApiResponse<CreateCategoryProductCommandResponse>>
{
    private readonly IProductWriteRepository productWriteRepository;
    private readonly IProductReadRepository productReadRepository;
    private readonly ICategoryReadRepository categoryReadRepository;

    public CreateCategoryProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, ICategoryReadRepository categoryReadRepository)
    {
        this.productWriteRepository= productWriteRepository;
        this.productReadRepository = productReadRepository;
        this.categoryReadRepository = categoryReadRepository;
    }

    public async Task<ApiResponse<CreateCategoryProductCommandResponse>> Handle(CreateCategoryProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await productReadRepository.GetByIdAsync(request.ProductId,cancellationToken);
        var category = await categoryReadRepository.GetByIdAsync(request.CategoryId,cancellationToken);
        if(product == null)
            return new ApiResponse<CreateCategoryProductCommandResponse>("Record Not Found1");
        if(category == null)
            return new ApiResponse<CreateCategoryProductCommandResponse>("Record Not Found");
        // Check if the product already has the category
        if (product.Categories.Any(c => c.Id == category.Id))
            return new ApiResponse<CreateCategoryProductCommandResponse>("Product already has the category");

        await productWriteRepository.AddProductWithCategories(product, category, cancellationToken);
        return new ApiResponse<CreateCategoryProductCommandResponse>(true);
    }
}

