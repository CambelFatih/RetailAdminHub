using AutoMapper;
using MediatR;
using RetailAdminHub.Application.Dto;
using RetailAdminHub.Domain.Base.Response;
using RetailAdminHub.Application.Abstractions.Uow;

namespace RetailAdminHub.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, ApiResponse<GetAllProductQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    async Task<ApiResponse<GetAllProductQueryResponse>> IRequestHandler<GetAllProductQueryRequest, ApiResponse<GetAllProductQueryResponse>>.Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var totalProductCount = unitOfWork.ProductReadRepository.GetAll(false).Where(x => x.IsActive).Count();
        var products = await unitOfWork.ProductReadRepository.GetProductsPagedWithCategoriesAsync(request.Page, request.Size, cancellationToken);
        var productDTOs = mapper.Map<List<ProductDetailDto>>(products);
        var response = new GetAllProductQueryResponse
        {
            TotalProductCount = totalProductCount,
            Products = productDTOs
        };
        return new ApiResponse<GetAllProductQueryResponse>(response);
    }
}
