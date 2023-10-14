using AutoMapper;
using MediatR;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Exceptions;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Response;

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
    async Task<ApiResponse<GetByIdCategoryQueryResponse>> IRequestHandler<GetByIdCategoryQueryRequest, ApiResponse<GetByIdCategoryQueryResponse>>.Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryReadRepository.GetCategoryWithProductsAsync(request.Id);

        if (category == null)
        {
            return new ApiResponse <GetByIdCategoryQueryResponse> ("Record not found", false);
        }

        var categoryDto = mapper.Map<CategoryDetailDTO>(category);
        return mapper.Map<ApiResponse<GetByIdCategoryQueryResponse>>(categoryDto);
    }
}

