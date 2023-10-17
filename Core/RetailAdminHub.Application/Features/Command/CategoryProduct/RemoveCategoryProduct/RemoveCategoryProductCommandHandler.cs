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
        bool success = await unitOfWork.ProductWriteRepository.RemoveCategoryProductAsync(request.ProductId, request.CategoryId);
        if (!success)       
            return new ApiResponse<RemoveCategoryProductCommandResponse>("Failed to remove CategoryProduct relation.");
          
        return new ApiResponse<RemoveCategoryProductCommandResponse>("CategoryProduct relation successfully removed.", true);
    }
}

