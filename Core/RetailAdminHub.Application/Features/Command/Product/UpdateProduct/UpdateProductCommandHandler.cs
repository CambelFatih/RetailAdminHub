using MediatR;
using Microsoft.Extensions.Logging;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ApiResponse<UpdateProductCommandResponse>>
{
    readonly IProductReadRepository _productReadRepository;
    readonly IProductWriteRepository _productWriteRepository;
    readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILogger<UpdateProductCommandHandler> logger)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _logger = logger;
    }

    public async Task<ApiResponse<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            _logger.LogError("No product found with the given ID.");
            return new ApiResponse<UpdateProductCommandResponse>("Record not found",false); 
        }

        product.Stock = request.Stock;
        product.Name = request.Name;
        product.Price = request.Price;

        await _productWriteRepository.SaveAsync();
        _logger.LogInformation("Product güncellendi...");
        return new ApiResponse<UpdateProductCommandResponse>(true);

    }
}
