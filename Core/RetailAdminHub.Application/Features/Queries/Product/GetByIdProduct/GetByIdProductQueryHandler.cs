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
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GetByIdProductQueryResponse>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _productReadRepository.GetProductWithCategoriesAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundProductException();
            }
            var productDto = _mapper.Map<ProductDetailDTO>(product);

            // Eğer gerekirse, ProductDTO'yu GetByIdProductQueryResponse'ye dönüştürün
            return _mapper.Map<ApiResponse<GetByIdProductQueryResponse>>(productDto);
        }
    }
}
