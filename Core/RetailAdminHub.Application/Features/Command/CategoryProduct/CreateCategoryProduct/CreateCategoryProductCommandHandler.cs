using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct;

public class CreateCategoryProductCommandHandler : IRequestHandler<CreateCategoryProductCommandRequest, ApiResponse<CreateCategoryProductCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateCategoryProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<CreateCategoryProductCommandResponse>> Handle(CreateCategoryProductCommandRequest request, CancellationToken cancellationToken)
    {
        // Retrieve the product and category by their respective IDs
        var product = await unitOfWork.ProductReadRepository.GetByIdAsync(request.ProductId,cancellationToken);
        var category = await unitOfWork.CategoryReadRepository.GetByIdAsync(request.CategoryId,cancellationToken);
        // Check if the product or category doesn't exist
        if (product == null)
            return new ApiResponse<CreateCategoryProductCommandResponse>("Record Not Found");
        if(category == null)
            return new ApiResponse<CreateCategoryProductCommandResponse>("Record Not Found");
        // Check if the product already has the category
        if (product.Categories != null)
        {
            if (product.Categories.Any(c => c.Id == category.Id))
                return new ApiResponse<CreateCategoryProductCommandResponse>("Conflict");//Product already has the category
            if (category.Products.Any(p => p.Id == product.Id))
                return new ApiResponse<CreateCategoryProductCommandResponse>("Conflict");//Product already has the category
        }
        // Associate the product with the category
        await unitOfWork.ProductWriteRepository.AddProductWithCategories(product, category, cancellationToken);
        // Return a response indicating a successful association
        return new ApiResponse<CreateCategoryProductCommandResponse>(true);
    }
}

