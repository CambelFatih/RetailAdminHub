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
        var result = await unitOfWork.ProductWriteRepository.SoftDeleteById(request.Id, cancellationToken);
        return new ApiResponse<RemoveProductCommandResponse>(result);
    }
}

