using MediatR;
using P = RetailAdminHub.Domain.Entities;
using RetailAdminHub.Application.Exceptions;
using AutoMapper;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Repositories.CategoryRepository;

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
            var product = await productReadRepository.GetProductWithCategoriesAsync(request.Id, cancellationToken);
            if (product == null)
                return new ApiResponse<GetByIdProductQueryResponse>("Record not found", false);
            var mapped = mapper.Map<GetByIdProductQueryResponse>(product);
            return new ApiResponse<GetByIdProductQueryResponse>(mapped);
        }
    }
}