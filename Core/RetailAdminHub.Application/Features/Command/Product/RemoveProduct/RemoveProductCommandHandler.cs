using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.RemoveProduct;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, ApiResponse<RemoveProductCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<RemoveProductCommandResponse>> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
    {
        // Call the SoftDeleteById method to mark a product for deletion (soft delete).
        var result = await unitOfWork.ProductWriteRepository.SoftDeleteById(request.Id, cancellationToken);
        // Create an ApiResponse with the result of the removal operation.
        return new ApiResponse<RemoveProductCommandResponse>(result);
    }
}

