using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ApiResponse<CreateProductCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        // Add a new product to the repository
        await unitOfWork.ProductWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            IsActive = true,
        });
        // Save changes to the product repository
        await unitOfWork.ProductWriteRepository.SaveAsync();
        // Return a response indicating a successful product creation
        return new ApiResponse<CreateProductCommandResponse>(true);    
    }
}

