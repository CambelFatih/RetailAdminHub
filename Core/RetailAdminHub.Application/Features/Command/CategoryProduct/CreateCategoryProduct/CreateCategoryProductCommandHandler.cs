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
        var product = await unitOfWork.ProductReadRepository.GetByIdAsync(request.ProductId,cancellationToken);
        var category = await unitOfWork.CategoryReadRepository.GetByIdAsync(request.CategoryId,cancellationToken);
        if(product == null)
            return new ApiResponse<CreateCategoryProductCommandResponse>("Record Not Found1");
        if(category == null)
            return new ApiResponse<CreateCategoryProductCommandResponse>("Record Not Found");
        // Check if the product already has the category
        if (product.Categories != null)
        {
            if (product.Categories.Any(c => c.Id == category.Id))
                return new ApiResponse<CreateCategoryProductCommandResponse>("Product already has the category");
        }
        await unitOfWork.ProductWriteRepository.AddProductWithCategories(product, category, cancellationToken);
        return new ApiResponse<CreateCategoryProductCommandResponse>(true);
    }
}

