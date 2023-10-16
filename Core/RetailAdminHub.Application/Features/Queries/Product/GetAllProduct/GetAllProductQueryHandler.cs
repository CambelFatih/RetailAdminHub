using AutoMapper;
using MediatR;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;
using RetailAdminHub.Application.Dto;

namespace RetailAdminHub.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, ApiResponse<GetAllProductQueryResponse>>
    {
        readonly IProductReadRepository productReadRepository;
        private readonly IMapper mapper;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            this.productReadRepository = productReadRepository;
            this.mapper = mapper;
        }

        async Task<ApiResponse<GetAllProductQueryResponse>> IRequestHandler<GetAllProductQueryRequest, ApiResponse<GetAllProductQueryResponse>>.Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalProductCount = productReadRepository.GetAll(false).Where(x => x.IsActive).Count();

            var products = await productReadRepository.GetProductsPagedWithCategoriesAsync(request.Page, request.Size);

            var productDTOs = mapper.Map<List<ProductDetailDto>>(products);
            var response = new GetAllProductQueryResponse
            {
                TotalProductCount = totalProductCount,
                Products = productDTOs
            };

            return new ApiResponse<GetAllProductQueryResponse>(response);
        }
    }
}