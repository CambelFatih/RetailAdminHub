using MediatR;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Base.Response;


namespace RetailAdminHub.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ApiResponse<CreateProductCommandResponse>>
    {

        private readonly IProductWriteRepository productWriteRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            this.productWriteRepository = productWriteRepository;
        }

        public async Task<ApiResponse<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {          
            try
            {
                await productWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    Price = request.Price,
                    Stock = request.Stock,
                    IsActive = true,
                });
                await productWriteRepository.SaveAsync();
               return new ApiResponse<CreateProductCommandResponse>(true);
            }
            catch (Exception e)
            {
                return new ApiResponse<CreateProductCommandResponse>(success:false,message:e.Message);
            }        
        }
    }
}
