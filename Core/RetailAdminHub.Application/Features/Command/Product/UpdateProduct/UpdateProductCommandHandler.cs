using MediatR;
using Microsoft.Extensions.Logging;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ApiResponse<UpdateProductCommandResponse>>
{
    readonly IProductReadRepository productReadRepository;
    readonly IProductWriteRepository productWriteRepository;
    public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        this.productReadRepository = productReadRepository;
        this.productWriteRepository = productWriteRepository;
    }

    public async Task<ApiResponse<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await productReadRepository.GetByIdAsync(request.Id);

        if (product == null)
            return new ApiResponse<UpdateProductCommandResponse>("Record not found",false); 
       
        product.Stock = request.Stock;
        product.Name = request.Name;
        product.Price = request.Price;
        await productWriteRepository.SaveAsync();
        return new ApiResponse<UpdateProductCommandResponse>(true);
    }
}
