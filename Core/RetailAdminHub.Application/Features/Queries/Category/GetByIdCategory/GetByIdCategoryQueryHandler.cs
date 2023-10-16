using AutoMapper;
using MediatR;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, ApiResponse<GetByIdCategoryQueryResponse>>
{
    private readonly IMapper mapper;
    private readonly ICategoryReadRepository categoryReadRepository;
    public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
    {
        this.categoryReadRepository = categoryReadRepository;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<GetByIdCategoryQueryResponse>> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryReadRepository.GetCategoryWithProductsAsync(request.Id, cancellationToken);
        if (category == null)      
            return new ApiResponse<GetByIdCategoryQueryResponse>("Record not found", false);
        
        var mapped = mapper.Map<GetByIdCategoryQueryResponse>(category);
        return new ApiResponse<GetByIdCategoryQueryResponse>(mapped);
    }
}

