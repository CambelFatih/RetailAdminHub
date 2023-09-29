using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
using RetailAdminHub.Application.Repositories;

namespace RetailAdminHub.Application.Features.Queries.Product.CreateProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

         async Task<GetAllProductQueryResponse> IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>.Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalProductCount = _productReadRepository.GetAll(false).Count();

            var products = await _productReadRepository.GetProductsPagedWithCategoriesAsync(request.Page, request.Size);

            var productDTOs = _mapper.Map<List<ProductDetailDTO>>(products);
            var response = new GetAllProductQueryResponse
            {
                TotalProductCount = totalProductCount,
                Products = productDTOs
            };

            return await Task.FromResult(response);
        }
    }
}
