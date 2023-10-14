using MediatR;
using P = RetailAdminHub.Domain.Entities;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Exceptions;
using AutoMapper;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, ApiResponse<GetByIdProductQueryResponse>>
    {
        private readonly IMapper mapper;
        private readonly IProductReadRepository productReadRepository;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            this.productReadRepository = productReadRepository;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<GetByIdProductQueryResponse>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await productReadRepository.GetProductWithCategoriesAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundProductException();
            }
            var productDto = mapper.Map<ProductDetailDTO>(product);

            // Eğer gerekirse, ProductDTO'yu GetByIdProductQueryResponse'ye dönüştürün
            return mapper.Map<ApiResponse<GetByIdProductQueryResponse>>(productDto);
        }
    }
}
