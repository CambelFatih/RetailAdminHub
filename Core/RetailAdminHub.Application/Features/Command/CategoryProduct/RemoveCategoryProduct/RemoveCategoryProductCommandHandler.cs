using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.RemoveCategoryProduct;

public class RemoveCategoryProductCommandHandler : IRequestHandler<RemoveCategoryProductCommandRequest, ApiResponse<RemoveCategoryProductCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveCategoryProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<RemoveCategoryProductCommandResponse>> Handle(RemoveCategoryProductCommandRequest request, CancellationToken cancellationToken)
    {
        // Attempt to remove the relationship between a product and a category
        bool success = await unitOfWork.ProductWriteRepository.RemoveCategoryProductAsync(request.ProductId, request.CategoryId);
        // Check if the removal was successful
        if (!success)       
            return new ApiResponse<RemoveCategoryProductCommandResponse>("Record not found", false);//Failed to remove CategoryProduct relation.
        // Return a response indicating the successful removal of the CategoryProduct relation
        return new ApiResponse<RemoveCategoryProductCommandResponse>("CategoryProduct relation successfully removed.", true);
    }
}

