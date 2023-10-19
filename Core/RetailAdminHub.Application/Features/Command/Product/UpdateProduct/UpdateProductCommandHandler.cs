using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ApiResponse<UpdateProductCommandResponse>>
{
    readonly IUnitOfWork unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        // Retrieve the product to be updated by its ID
        var product = await unitOfWork.ProductReadRepository.GetByIdAsync(request.Id);
        // Check if the product exists
        if (product == null)
            return new ApiResponse<UpdateProductCommandResponse>("Record not found",false);
        // Update product properties with the values from the request
        product.Stock = request.Stock;
        product.Name = request.Name;
        product.Price = request.Price;
        // Save the updated product
        await unitOfWork.ProductWriteRepository.SaveAsync();
        // Return a response indicating a successful update
        return new ApiResponse<UpdateProductCommandResponse>(true);
    }
}
