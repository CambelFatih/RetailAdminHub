using MediatR;
using AutoMapper;
using RetailAdminHub.Domain.Base.Response;
using RetailAdminHub.Application.Abstractions.Uow;

namespace RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, ApiResponse<GetByIdProductQueryResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GetByIdProductQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<GetByIdProductQueryResponse>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.ProductReadRepository.GetProductWithCategoriesAsync(request.Id, cancellationToken);
        if (product == null)
            return new ApiResponse<GetByIdProductQueryResponse>("Record not found", false);
        var mapped = mapper.Map<GetByIdProductQueryResponse>(product);
        return new ApiResponse<GetByIdProductQueryResponse>(mapped);
    }
}
