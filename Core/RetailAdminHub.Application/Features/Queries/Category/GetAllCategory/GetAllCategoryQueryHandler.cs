using AutoMapper;
using MediatR;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, ApiResponse<GetAllCategoryQueryResponse>>
{
    private readonly ICategoryReadRepository categoryReadRepository;
    private readonly IMapper mapper;

    public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
    {
        this.categoryReadRepository = categoryReadRepository;
        this.mapper = mapper;
    }

        async Task<ApiResponse<GetAllCategoryQueryResponse>> IRequestHandler<GetAllCategoryQueryRequest, ApiResponse<GetAllCategoryQueryResponse>>.Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = categoryReadRepository.GetAll(false).Where(x => x.IsActive).ToList();
        var categoriesDTOs = mapper.Map<List<CategoryDetailDTO>>(categories);

        var response = new GetAllCategoryQueryResponse
        {
            Categories = categoriesDTOs
        };

        return  new ApiResponse<GetAllCategoryQueryResponse>(response);
    }
}

