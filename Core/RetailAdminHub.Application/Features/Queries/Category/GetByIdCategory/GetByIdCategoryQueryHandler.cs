using AutoMapper;
using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, ApiResponse<GetByIdCategoryQueryResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GetByIdCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<GetByIdCategoryQueryResponse>> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryReadRepository.GetCategoryWithProductsAsync(request.Id, cancellationToken);
        if (category == null)      
            return new ApiResponse<GetByIdCategoryQueryResponse>("Record not found", false);
        
        var mapped = mapper.Map<GetByIdCategoryQueryResponse>(category);
        return new ApiResponse<GetByIdCategoryQueryResponse>(mapped);
    }
}

