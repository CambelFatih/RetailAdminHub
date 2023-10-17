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
        var product = await unitOfWork.ProductReadRepository.GetByIdAsync(request.Id);

        if (product == null)
            return new ApiResponse<UpdateProductCommandResponse>("Record not found",false); 
       
        product.Stock = request.Stock;
        product.Name = request.Name;
        product.Price = request.Price;
        await unitOfWork.ProductWriteRepository.SaveAsync();
        return new ApiResponse<UpdateProductCommandResponse>(true);
    }
}
